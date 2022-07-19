namespace DerpeSteamKeyGen
{
    /// <summary>
    /// Enumeration of directions.
    /// </summary>
    enum Direction { DOWN_LEFT, DOWN_RIGHT, UP_LEFT, UP_RIGHT }

    public partial class MainForm : Form
    {
        #region Variables

        /// <summary>
        /// Stores path to key list (example: "D:\\keys.txt").
        /// </summary>
        string keylistPath;


        /// <summary>
        /// Stores width and height of active space border.
        /// </summary>
        readonly Point formInternalBorder = new(219, 205);


        /// <summary>
        /// Used by 'Gradient' background option.
        /// </summary>
        System.Windows.Forms.Timer gradientTimer = new();

        /// <summary>
        /// Used by 'Gradient' background option. Stores target color.
        /// </summary>
        Color gradientTargetColor = Color.White;


        /// <summary>
        /// Used by 'Wawus With Balloon' bouncing picturebox.
        /// </summary>
        System.Windows.Forms.Timer wawusTimer = new();

        /// <summary>
        /// Used by 'Wawus With Balloon' bouncing picturebox. Stores direction of 'Wawus' movement.
        /// </summary>
        Direction wawusDir;

        #endregion



        #region Constructor

        /// <summary>
        /// Main Form constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            gradientTimer.Tick += new EventHandler(ColorGenerationStyle);
            wawusTimer.Tick += new EventHandler(MoveWawus);

            gradientTimer.Interval = 1;
            wawusTimer.Interval = 1;
        }

        #endregion



        #region Service Methods

            #region Key Generation

        /// <summary>
        /// Randomly generates a key-valid char.
        /// </summary>
        char GenerateKeyValidChar()
        {
            var rnd = new Random();
            char validchar;

            do
            {
                validchar = (char)rnd.Next(48, 90);

            } while (validchar > '9' && validchar < 'A');

            return validchar;
        }

        /// <summary>
        /// Generates and returns a randomly generated key in AAAAA-BBBBB-CCCCC (5_5_5) format.
        /// </summary>
        string GenerateNewKey5_5_5()
        {
            System.Text.StringBuilder key = new("AAAAA-BBBBB-CCCCC");

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] == '-')
                    continue;

                key[i] = GenerateKeyValidChar();
            }

            return key.ToString();
        }

        #endregion


            #region Working With Files

        /// <summary>
        /// Checks if keyslist file exists in 'keylistPath'. If not, promts user to make a new one in the same path.
        /// </summary>
        bool FileExists()
        {
            if (!File.Exists(keylistPath))
            {
                DialogResult message = MessageBox.Show("Keys list file does not exist in directory! Do you want to make a new one?", "Warning!", MessageBoxButtons.YesNo);
                switch (message)
                {
                    case DialogResult.Yes:
                        return NewFile();

                    case DialogResult.No:
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Makes a new keyslist file in 'keylistPath'.
        /// </summary>
        bool NewFile()
        {
            try
            {
                System.IO.FileStream f = System.IO.File.Create(keylistPath);
                f.Close();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Error! Unauthorized Access!");
                return false;
            }
            catch
            {
                MessageBox.Show("Error!");
                return false;
            }

            MessageBox.Show("File created!");
            return true;
        }

        /// <summary>
        /// Checks if given key is unique in a given file.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        bool CheckIfKeyIsUnique(string key, string path)
        {
            if (!FileExists())
                return false;

            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (line == key)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Saves given key in given path.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        void SaveKeyToFile(string key, string path)
        {
            if (!FileExists())
                return;

            File.AppendAllText(path, key + Environment.NewLine);
        }

            #endregion

            
            #region Working With Menus

        /// <summary>
        /// Changes 'Checked' state of all 'root' parent strip menu items to 'false' and sets 'true' to 'index' item.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="index"></param>
        void SetCheckByIndex(ToolStripMenuItem root, int index)
        {
            var itemlist = root.DropDownItems;
            for (int i = 0; i < itemlist.Count; i++)
            {
                var tmp = (ToolStripMenuItem)itemlist[i];
                tmp.Checked = false;

                if (i == index)
                    tmp.Checked = true;
            }
        }

        /// <summary>
        /// Returns item index from 'root' that is 'Checked'.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int GetCheckedItemIndex(ToolStripMenuItem root)
        {
            var itemlist = root.DropDownItems;
            for (int i = 0; i < itemlist.Count; i++)
            {
                var tmp = (ToolStripMenuItem)itemlist[i];
                if (tmp.Checked)
                    return i;
            }
            return 0;
        }

        void ClickStripMenuItemOnIndex(ToolStripMenuItem root, int index)
        {
            var itemlist = root.DropDownItems;
            itemlist[index].PerformClick();
        }


        /// <summary>
        /// Controls settings of item switch from 'UI' -> 'Background' parent menu strip. 'item' is an index of item that user chooses.
        /// </summary>
        void BackgroundStripMenuItemMaster(int item)
        {
            StopAllBackgroundElements();
            SetCheckByIndex(StripMenuItem_Background, item);
        }
        
        /// <summary>
        /// Turns off all 'Background' menu strip element actions.
        /// </summary>
        void StopAllBackgroundElements()
        {
            PictureBox_SaulGoodman.Hide();
            gradientTimer.Stop();
        }

            #endregion


            #region Working With Elements

        /// <summary>
        /// Moves 'Wawus' picturebox around the whole screen. If he hits a corner, program closes.
        /// </summary>
        private void MoveWawus(object? sender, EventArgs e)
        {
            Point point = PictureBox_WawusWithBalloon.Location;

            // Change Wawus location
            switch (wawusDir)
            {
                case Direction.DOWN_LEFT:
                    point.X--;
                    point.Y++;
                    break;

                case Direction.DOWN_RIGHT:
                    point.X++;
                    point.Y++;
                    break;

                case Direction.UP_LEFT:
                    point.X--;
                    point.Y--;
                    break;

                case Direction.UP_RIGHT:
                    point.X++;
                    point.Y--;
                    break;
            }

            // If Wawus hit a corner
            if (point.X == 0 && point.Y == 0 ||
                point.X == 0 && point.Y == formInternalBorder.Y ||
                point.X == formInternalBorder.X && point.Y == 0 ||
                point.X == formInternalBorder.X && point.Y == formInternalBorder.Y)
            {
                MessageBox.Show("Congratulations! Wawus hit a corner! Exiting program now.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }


            PictureBox_WawusWithBalloon.Location = point;


            // Change direction for next tick if form border is hit

            Point size = new Point(PictureBox_WawusWithBalloon.Size);

            // Left wall - X
            if (point.X == 0 && wawusDir == Direction.UP_LEFT)
                wawusDir = Direction.UP_RIGHT;
            if (point.X == 0 && wawusDir == Direction.DOWN_LEFT)
                wawusDir = Direction.DOWN_RIGHT;

            // Right wall - X
            if (point.X + size.X == formInternalBorder.X && wawusDir == Direction.DOWN_RIGHT)
                wawusDir = Direction.DOWN_LEFT;
            if (point.X + size.X == formInternalBorder.X && wawusDir == Direction.UP_RIGHT)
                wawusDir = Direction.UP_LEFT;

            // Upper wall - Y
            if (point.Y == 0 && wawusDir == Direction.UP_LEFT)
                wawusDir = Direction.DOWN_LEFT;
            if (point.Y == 0 && wawusDir == Direction.UP_RIGHT)
                wawusDir = Direction.DOWN_RIGHT;

            // Bottom wall - Y
            if (point.Y + size.Y == formInternalBorder.Y && wawusDir == Direction.DOWN_LEFT)
                wawusDir = Direction.UP_LEFT;
            if (point.Y + size.Y == formInternalBorder.Y && wawusDir == Direction.DOWN_RIGHT)
                wawusDir = Direction.UP_RIGHT;
        }

            #endregion


            #region Colors

        /// <summary>
        /// Changes 'formBackgroundColor' values to match the 'gradientTargetColor' values. When target is met, generate new random 'gradientTargetColor' values.
        /// </summary>
        Color GradientColorGenerator(Color background)
        {
            int[] _b = ColorToArray(background);
            int[] _t = ColorToArray(gradientTargetColor);

            // Change array values
            for (int i = 0; i < 3; i++)
            {
                if (_b[i] > _t[i])
                    _b[i]--;

                if (_b[i] < _t[i])
                    _b[i]++;
            }

            // Check if target is hit, if true generates a new target
            if (_b[0] == _t[0] && _b[1] == _t[1] && _b[2] == _t[2])
            {
                Random rnd = new();
                int min = 40;
                int max = 255;
                _t = new int[] { rnd.Next(min, max), rnd.Next(min, max), rnd.Next(min, max) };

                gradientTargetColor = ArrayToColor(_t);
            }

            background = ArrayToColor(_b);
            return background;
        }

        /// <summary>
        /// Changes background color of 'BackColor' and 'FormStrip'.
        /// </summary>
        void SetBackgroundColor(Color background)
        {
            this.BackColor = background;
            MainFormStrip.BackColor = background;
        }

        /// <summary>
        /// Set style of RGB generation.
        /// </summary>
        void ColorGenerationStyle(object? sender, EventArgs e)
        {
            SetBackgroundColor(GradientColorGenerator(this.BackColor));
        }

            #endregion


            #region Converters

        /// <summary>
        /// Returns int values in array from given color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        int[] ColorToArray(Color color)
        {
            int[] arr = { color.R, color.G, color.B };
            return arr;
        }

        /// <summary>
        /// Returns Color object from given int array values.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        Color ArrayToColor(int[] arr)
        {
            if (arr.Length != 3)
                return Color.Red;

            foreach (var value in arr)
                if (value < 0 || value > 255)
                    return Color.Red;

            return Color.FromArgb(arr[0], arr[1], arr[2]);
        }

            #endregion


            #region Other

        /// <summary>
        /// Copies given text to Windows clipboard.
        /// </summary>
        /// <param name="text"></param>
        private void CopyToClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        /// <summary>
        /// Promts user to navigate to the desired path. Returns path as string.
        /// </summary>
        private string GetFolderBrowserPath()
        {
            FolderBrowserDialog newpathdialog = new();

            if (newpathdialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return "";

            return newpathdialog.SelectedPath;
        }

            #endregion

        #endregion



        #region Button - Generate Key

        /// <summary>
        /// When clicked, generates a new random key and copies it to textbox. Also can copy / save key in file if specific flags are set ON.
        /// </summary>
        private void Button_GenerateKey_Click(object sender, EventArgs e)
        {
            string key = GenerateNewKey5_5_5();
            TextBox_Key.Text = key;

            if (Flag_CopyToBuffer.Checked)
            {
                CopyToClipboard(key);
            }

            if (Flag_SaveToFile.Checked)
            {
                if (CheckIfKeyIsUnique(key, keylistPath))
                {
                    SaveKeyToFile(key, keylistPath);
                }
                else
                {
                    MessageBox.Show("Duplicate key generated! Aborting saving.");
                }
            }
        }

        #endregion



        #region Strip Menu - Saved Keys

        /// <summary>
        /// When clicked, opens a keylist file in a default user app.
        /// </summary>
        private void StripMenuItem_OpenFile_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;

            System.Diagnostics.Process.Start("explorer", keylistPath);
        }

        /// <summary>
        /// When clicked, opens a directory, where keylist file is stored.
        /// </summary>
        private void StripMenuItem_OpenDirectory_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;

            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(keylistPath));
        }

        /// <summary>
        /// When clicked, promts user to navigate to desired path where keylist file will be stored. Overrides the file if there's a copy with the same name.
        /// </summary>
        private void StripMenuItem_ChangeDirectory_Click(object sender, EventArgs e)
        {
            string oldpath = keylistPath;
            string newpath = GetFolderBrowserPath() + Path.GetFileName(keylistPath);

            if (oldpath == newpath)
            {
                MessageBox.Show("This is the same directory.");
                return;
            }

            if (!FileExists())
            {
                keylistPath = newpath;
                return;
            }

            try
            {
                File.Copy(oldpath, newpath);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Error! Unauthorized Access!");
                return;
            }
            catch (System.IO.IOException)
            {
                DialogResult message = MessageBox.Show("File with the same name already exists in this folder! Overwrite it?", "Warning!", MessageBoxButtons.YesNo);
                switch(message)
                {
                    case DialogResult.Yes:
                        File.Delete(newpath);
                        File.Copy(oldpath, newpath);
                        break;

                    case DialogResult.No:
                        return;
                }
            }
            catch
            {
                MessageBox.Show("Error!");
                return;
            }

            File.Delete(oldpath);
            keylistPath = newpath;
        }

        /// <summary>
        /// When clicked, deletes everything in keylist file.
        /// </summary>
        private void StripMenuItem_ClearAll_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;

            DialogResult message = MessageBox.Show("Are you sure that you want to erase all the keys?", "Warning!", MessageBoxButtons.YesNo);
            switch (message)
            {
                case DialogResult.Yes:
                    File.WriteAllText(keylistPath, String.Empty);
                    return;

                case DialogResult.No:
                    return;
            }
        }

        #endregion



        #region Strip Menu - UI

            #region Background

        /// <summary>
        /// Enable or disable white background.
        /// </summary>
        private void StripMenuItem_White_Click(object sender, EventArgs e)
        {
            BackgroundStripMenuItemMaster(0);
            SetBackgroundColor(Color.White);
        }

        /// <summary>
        /// Promts user to pick their own color.
        /// </summary>
        private void StripMenuItem_PickColor_Click(object sender, EventArgs e)
        {
            BackgroundStripMenuItemMaster(1);

            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetBackgroundColor(colorDialog.Color);
            }
        }

        /// <summary>
        /// Enable or disable gradient background.
        /// </summary>
        private void StripMenuItem_Gradient_Click(object sender, EventArgs e)
        {
            BackgroundStripMenuItemMaster(2);
            gradientTimer.Start();
        }

        /// <summary>
        /// Enable or disable Saul Goodman background.
        /// </summary>
        private void StripMenuItem_SaulGoodman_Click(object sender, EventArgs e)
        {
            BackgroundStripMenuItemMaster(3);
            PictureBox_SaulGoodman.Show();
            SetBackgroundColor(Color.SaddleBrown);
        }

            #endregion


            #region Other

        /// <summary>
        /// Enable or disable derpes dancing on the main form. (Don't disable them, they are cool :3)
        /// </summary>
        private void StripMenuItem_Derpe_Click(object sender, EventArgs e)
        {
            StripMenuItem_Derpe.Checked = !StripMenuItem_Derpe.Checked;
            DerpeLeft.Visible = !DerpeLeft.Visible;
            DerpeRight.Visible = !DerpeRight.Visible;
        }

        /// <summary>
        /// Enable or disable Wawus With Balloon.
        /// </summary>
        private void StripMenuItem_WawusWithBalloon_Click(object sender, EventArgs e)
        {
            StripMenuItem_WawusWithBalloon.Checked = !StripMenuItem_WawusWithBalloon.Checked;

            if (StripMenuItem_WawusWithBalloon.Checked)
            {
                Random rnd = new();

                int x = PictureBox_WawusWithBalloon.Width;
                int y = PictureBox_WawusWithBalloon.Height;

                wawusDir = (Direction)rnd.Next((int)Direction.DOWN_LEFT, (int)Direction.UP_RIGHT);

                PictureBox_WawusWithBalloon.Location = new Point(rnd.Next(x, formInternalBorder.X - x), 
                                                                 rnd.Next(y, formInternalBorder.Y - y));

                PictureBox_WawusWithBalloon.Show();
                wawusTimer.Start();
            }
            else
            {
                PictureBox_WawusWithBalloon.Hide();
                wawusTimer.Stop();
            }
        }

            #endregion

        #endregion



        #region Strip Menu - Links

        /// <summary>
        /// When clicked, opens this project github page!
        /// </summary>
        private void StripMenuItem_Github_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = "https://github.com/derpedcatto/DerpeSteamKeyGen";
            System.Diagnostics.Process.Start(psi);
        }

        #endregion



        #region Saving/Loading User Preferences (Registry)

        /// <summary>
        /// Saves user preferences in registry file.
        /// </summary>
        private void MainForm_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\DerpeSteamKeyGen");

            // File
            key.SetValue("Keylist Path", keylistPath);
            key.SetValue("Copy To Clipboard Check", Flag_CopyToBuffer.Checked);
            key.SetValue("Save To File Check", Flag_SaveToFile.Checked);

            // Background Color
            key.SetValue("Background Color", this.BackColor.ToArgb());

            // Strip Menu - Background
            key.SetValue("Background Style Index", GetCheckedItemIndex(StripMenuItem_Background));

            // Strip Menu - Other
            key.SetValue("Derpe Check", StripMenuItem_Derpe.Checked);
            key.SetValue("Wawus With Balloon Check", StripMenuItem_WawusWithBalloon.Checked);

            key.Close();
        }

        /// <summary>
        /// Loads user preferences from registry file.
        /// </summary>
        private void MainForm_OnFormLoad(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\DerpeSteamKeyGen");

            // Generate default settings
            if (key == null)
            {
                // File
                keylistPath = Path.GetFullPath("keys.txt");
                Flag_CopyToBuffer.Checked = true;
                Flag_SaveToFile.Checked = false;

                // Strip Menu - Background
                StripMenuItem_Gradient_Click(sender, e);

                // Strip Menu - Other
                StripMenuItem_Derpe_Click(sender, e);   // Show derpe by default
                // Wawus hidden by default
            }

            // Load user preferences
            else
            {
                // File
                keylistPath = (string)key.GetValue("Keylist Path");
                Flag_CopyToBuffer.Checked = bool.Parse(key.GetValue("Copy To Clipboard Check").ToString());                 
                Flag_SaveToFile.Checked = bool.Parse(key.GetValue("Save To File Check").ToString());

                // Background Color
                SetBackgroundColor(Color.FromArgb((int)key.GetValue("Background Color")));

                // Strip Menu - Background
                int backgroundIndex = (int)key.GetValue("Background Style Index");
                if (backgroundIndex != 1)   // Hide colorpicker menu if color is already chosen
                    ClickStripMenuItemOnIndex(StripMenuItem_Background, backgroundIndex);
                else
                    BackgroundStripMenuItemMaster(1);


                // Strip Menu - Other
                if (bool.Parse(key.GetValue("Derpe Check").ToString()))
                    StripMenuItem_Derpe_Click(sender, e);
                if (bool.Parse(key.GetValue("Wawus With Balloon Check").ToString()))
                    StripMenuItem_WawusWithBalloon_Click(sender, e);
            }
        }

        #endregion
    }
}