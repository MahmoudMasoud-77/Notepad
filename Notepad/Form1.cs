namespace Notepad
{
    public partial class Form1 : Form
    {

        public void NewFile()
        {
            try
            {
                if(!string.IsNullOrEmpty(this.richTextBox1.Text))
                    MessageBox.Show("save first");
                else
                {
                    this.richTextBox1.Text =string.Empty;
                    this.Text = "Untitled";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open";
            ofd.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(ofd.FileName,RichTextBoxStreamType.PlainText);
            this.Text = ofd.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sfd = new SaveFileDialog();
            Sfd.Title = "Save";
            Sfd.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (Sfd.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(Sfd.FileName, RichTextBoxStreamType.PlainText);
            this.Text = Sfd.FileName;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.richTextBox1.Text))
            {
                SaveFileDialog Sfd = new SaveFileDialog();
                Sfd.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                if(Sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(Sfd.FileName, this.richTextBox1.Text);
                    this.Text=Sfd.FileName;
                }
            }
            else
            {
                MessageBox.Show("there is no text");

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = DateTime.Now.ToString();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = colorDialog.Color;
        }
    }
}