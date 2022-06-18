using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Jonah Young
 * Assignment 5: Modified Playfair Cipher
 * 12/6/2020
 * C# 1
 */

namespace JRYPlayfairCipherLab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeywordTB.CharacterCasing = CharacterCasing.Upper;
            PhraseTB.CharacterCasing = CharacterCasing.Upper;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public bool IsLetterInMatrix(char letter, char[,] matrix)
        {
            bool isFound = false;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (matrix[row, col] == letter)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                break;
                
            }

            return isFound;
        }

        public char[,] Populate(string word)
        {

            string alphabetStr = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string allLetters = word + alphabetStr;

            char[,] matrix = new char[5, 5];

            int row = 0;
            int col = 0;

            foreach (char letter in allLetters)
            {
                if (!IsLetterInMatrix(letter, matrix))
                {
                    matrix[row, col] = letter;
                    col++;
                    if (col > 4)
                    {
                        row++;
                        col = 0;
                    }

                }
            }

            return matrix;
        }

        public string EncryptPhrase(string phrase, char[,] matrix)
        {
            string encryptedPhrase = "";

            foreach (var letter in phrase)
            {
                bool isFound = false;
                for (int i = 0; i <= matrix.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                    {
                        if (matrix[i, j] == letter)
                        {
                            isFound = true;
                            encryptedPhrase += matrix[j, i];
                            break;
                        }
                    }
                    if (isFound)
                        break;
                }

                if (!isFound)
                    encryptedPhrase += letter;
            }

            return encryptedPhrase;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = KeywordTB.Text;
            string phrase = PhraseTB.Text;

            string encryptedPhrase;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Please enter a keyword");
            }

            if (string.IsNullOrWhiteSpace(phrase))
            {
                MessageBox.Show("Please enter a phrase to encrypt");
            }

            char[,] matrix = Populate(keyword);

            encryptedPhrase = EncryptPhrase(phrase, matrix);

            EncryptedPhraseTB.Text = encryptedPhrase;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}