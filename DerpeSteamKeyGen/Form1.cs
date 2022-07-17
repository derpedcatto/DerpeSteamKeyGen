namespace DerpeSteamKeyGen
{
    public partial class MainForm : Form
    {
        #region Variables - Background

        private static System.Windows.Forms.Timer TIMER = new();
        bool backgroundAnimated = true;
        int[] colorVal = { 255, 255, 255 };
        bool[] colorSwitch = { false, false, false };

        #endregion


        #region MainForm

        public MainForm()
        {
            InitializeComponent();

            TIMER.Tick += new EventHandler(ARGBGenerationStyle);
            TIMER.Interval = 90;
            TIMER.Start();
        }

        #endregion


        #region Service Methods

        #region Colors

        /// <summary>
        /// Generates a random close-to-original color based of signature array values.
        /// </summary>
        private void ARGBPulsatingColorGenerator(int[] valueArr, bool[] switchArr)
        {
            var rnd = new Random();

            for (int i = 0; i < colorVal.Length; i++)
            {
                if (valueArr[i] >= 215)
                {
                    switchArr[i] = true;
                }
                else if (valueArr[i] <= 50)
                {
                    switchArr[i] = false;
                }

                if (switchArr[i])
                {
                    valueArr[i] -= rnd.Next(rnd.Next(40));
                }
                else if (!switchArr[i])
                {
                    valueArr[i] += rnd.Next(rnd.Next(40));
                }
            }
        }

        /// <summary>
        /// Set style of ARGB generation that TIMER Handle will use.
        /// </summary>
        private void ARGBGenerationStyle(object? sender, EventArgs e)
        {
            ARGBPulsatingColorGenerator(colorVal, colorSwitch);

            SetBackGroundARGB(colorVal[0], colorVal[1], colorVal[2]);
        }

        /// <summary>
        /// Changes background color of form backgrounds.
        /// </summary>
        private void SetBackGroundARGB(int R, int G, int B)
        {
            this.BackColor = Color.FromArgb(R, G, B);
            MainFormStrip.BackColor = this.BackColor;
        }

        #endregion


        #region Key Generation

        /// <summary>
        /// Randomly generates a key-valid char.
        /// </summary>
        private char GenerateValidChar()
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
        private string GenerateNewKey5_5_5()
        {
            char[] key = new char[Program.KEY.Length];

            int counter = 0;
            for (int i = 0; i < Program.KEY.Length; i++)
            {
                if (counter == 5)
                {
                    key[i] = '-';
                    counter = 0;
                    continue;
                }

                key[i] = GenerateValidChar();
                counter++;
            }

            return new string(key);
        }

        #endregion


        #region Working With Files

        /// <summary>
        /// Checks if key list file exists in 'LISTPATH'. If not, promts user to make a new one in the same path.
        /// </summary>
        private bool FileExists()
        {
            if (!File.Exists(Program.LISTPATH))
            {
                DialogResult message = MessageBox.Show("Keys list file does not exist! Do you want to make a new one?", "Warning!", MessageBoxButtons.YesNo);
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
        /// Makes a new key list file in 'LISTPATH' path.
        /// </summary>
        private bool NewFile()
        {
            try
            {
                System.IO.FileStream f = System.IO.File.Create(Program.LISTPATH);
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

            MessageBox.Show("File created at default category!");
            return true;
        }

        /// <summary>
        /// Checks if given key is unique in a given file. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        private bool CheckUniqueKey(string key, string path)
        {
            if (!FileExists())
                return false;

            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (line == key)
                {
                    MessageBox.Show("Duplicate key generated! Aborting save.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Saves given key in given path. Checks for duplicates, so all keys are unique
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        private void SaveKeyToFile(string key, string path)
        {
            if (!FileExists())
                return;

            File.AppendAllText(path, key + Environment.NewLine);
        }

        #endregion


        #region Other

        /// <summary>
        /// Copies given text to clipboard.
        /// </summary>
        /// <param name="text"></param>
        private void CopyToClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        /// <summary>
        /// Promts user to navigate to the desired path, and returns it as string.
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
        /// When clicked, generates a new random key. Also can copy / save key in file if specific flags are set ON.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_GenerateKey_Click(object sender, EventArgs e)
        {
            Program.KEY = GenerateNewKey5_5_5();
            TextBox_Key.Text = Program.KEY;

            if (Flag_CopyToBuffer.Checked)
            {
                CopyToClipboard(Program.KEY);
            }

            if (Flag_SaveToFile.Checked)
            {
                if (CheckUniqueKey(Program.KEY, Program.LISTPATH))
                {
                    SaveKeyToFile(Program.KEY, Program.LISTPATH);
                }
            }
        }

        #endregion


        #region Strip Menu - Saved Keys

        private void StripMenuItem_OpenFile_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;
            
            System.Diagnostics.Process.Start("explorer", Program.LISTPATH);
        }

        private void StripMenuItem_OpenDirectory_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;

            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(Program.LISTPATH));
        }

        private void StripMenuItem_ChangeDirectory_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;

            string oldpath = Program.LISTPATH;
            string newpath = GetFolderBrowserPath() + Path.GetFileName(Program.LISTPATH);

            if (oldpath == newpath)
            {
                MessageBox.Show("This is the same directory.");
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
            Program.LISTPATH = newpath;
        }

        private void StripMenuItem_ClearAll_Click(object sender, EventArgs e)
        {
            if (!FileExists())
                return;

            DialogResult message = MessageBox.Show("Are you sure that you want to erase all the keys?", "Warning!", MessageBoxButtons.YesNo);
            switch (message)
            {
                case DialogResult.Yes:
                    File.WriteAllText(Program.LISTPATH, String.Empty);
                    return;

                case DialogResult.No:
                    return;
            }
        }

        #endregion


        #region Strip Menu - Background

        private void StripMenuItem_ToggleBackground_Click(object sender, EventArgs e)
        {
            if (backgroundAnimated)
            {
                TIMER.Stop();

                SetBackGroundARGB(255, 255, 255);

                StripMenuItem_ToggleBackground.Checked = false;

                backgroundAnimated = false;
            }
            else
            {
                TIMER.Start();

                StripMenuItem_ToggleBackground.Checked = true;
                backgroundAnimated = true;
            }
        }

        private void StripMenuItem_Derpe_Click(object sender, EventArgs e)
        {
            StripMenuItem_Derpe.Checked = !StripMenuItem_Derpe.Checked;
            DerpeLeft.Visible = !DerpeLeft.Visible;
            DerpeRight.Visible = !DerpeRight.Visible;
        }

        #endregion


        #region Strip Menu - Links

        private void StripMenuItem_Github_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = "https://github.com/derpedcatto";
            System.Diagnostics.Process.Start(psi);
        }

        #endregion
    }
}