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
        Dictionary<char, string> HuffmanEncodingDictionary;
        Dictionary<string, char> HuffmanDecodingDictionary;
        public Form1()
        {
            InitializeComponent();
            HuffmanEncodingDictionary = new Dictionary<char, string>();
            HuffmanDecodingDictionary = new Dictionary<string, char>();
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                HuffmanEncodingDictionary = HuffmanAlgorithm.CreateHuffmanEncodingDictionary(ofd.FileName);
                HuffmanDecodingDictionary = HuffmanEncodingDictionary.ToDictionary(x => x.Value, x => x.Key);
            }
            listBoxCodes.Items.Clear();
            foreach(var code in HuffmanEncodingDictionary)
            {
                listBoxCodes.Items.Add($"{code.Key} - {code.Value}");
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
                    string encodedText = HuffmanAlgorithm.EncodeString(ofdTake.FileName, HuffmanEncodingDictionary);

                    OpenFileDialog ofdPlace = new OpenFileDialog();
                    if (ofdPlace.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(ofdPlace.FileName, encodedText);
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
                    string decodedText = HuffmanAlgorithm.DecodeString(ofdTake.FileName, HuffmanDecodingDictionary);

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
