using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrequencyDictionary_Forms
{
    public partial class Form1 : Form
    {
        HuffmanAlgorithm huffmanAlgorithm;
        public Form1()
        {
            InitializeComponent();
            huffmanAlgorithm = new HuffmanAlgorithm();
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                huffmanAlgorithm.CreateHuffmanEncodingDictionary(ofd.FileName);
            }
            listBoxCodes.Items.Clear();
            listBoxCompession.Items.Clear();
            foreach(var code in huffmanAlgorithm.EncodingDictionary)
            {
                listBoxCodes.Items.Add($"[{code.Key}] - {code.Value}");
            }
        }

        private void buttonEncodeText_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select the file with text to encode, then the file to save encoded text");
            OpenFileDialog ofdTake = new OpenFileDialog();
            try
            {
                if (ofdTake.ShowDialog() == DialogResult.OK)
                {
                    string encodedText = huffmanAlgorithm.EncodeString(ofdTake.FileName);

                    OpenFileDialog ofdPlace = new OpenFileDialog();
                    if (ofdPlace.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(ofdPlace.FileName, encodedText);
                        listBoxCompession.Items.Add("Коэффициент сжатия: " + huffmanAlgorithm.CompressionRatio);
                        MessageBox.Show("Converted successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select the file with text to decode, then the file to save decoded text");
            OpenFileDialog ofdTake = new OpenFileDialog();
            try
            {
                if (ofdTake.ShowDialog() == DialogResult.OK)
                {
                    string decodedText = huffmanAlgorithm.DecodeString(ofdTake.FileName);

                    OpenFileDialog ofdPlace = new OpenFileDialog();
                    if (ofdPlace.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(ofdPlace.FileName, decodedText);
                        MessageBox.Show("Converted successfully!");
                    }
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
