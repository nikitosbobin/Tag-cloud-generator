using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tag_Cloud_Generator
{
    public partial class NewFileForm : Form
    {
        public int Width => (int) widthNumericInput.Value;
        public int Height => (int) heightNumericInput.Value;

        public NewFileForm() 
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void patternSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sizeString = (string) ((ComboBox) sender).SelectedItem;
            var abc = Regex.Match(sizeString, ".*?([0-9]*)x([0-9]*)");
            var width = int.Parse(abc.Groups[1].ToString());
            var height = int.Parse(abc.Groups[2].ToString());
            widthNumericInput.Value = width;
            heightNumericInput.Value = height;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
