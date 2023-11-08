using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareReliability4
{
    public partial class Form1 : Form
    {
        private double _stepsCount = 0;
        private double _probabilityOverall = 0;
        private double _probabilityFirst = 0;
        private double _probabilitySecond = 0;
        private double _probabilityThird = 0;
        private double _probabilityForth = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            double successCount = 0;
            //bool isSuccess = false;
            _stepsCount = ToDouble(tb_experimentCount.Text); // Количество испытаний
            Random rnd = new Random();
            Random rnd1 = new Random(rnd.Next(1000));
            Random rnd2 = new Random(rnd.Next(1000));
            Random rnd3 = new Random(rnd.Next(1000));
            Random rnd4 = new Random(rnd.Next(1000));
            Random rnd5 = new Random(rnd.Next(1000));
            Random rnd6 = new Random(rnd.Next(1000));
            Random rnd7 = new Random(rnd.Next(1000));
            Random rnd8 = new Random(rnd.Next(1000));
            Random rnd9 = new Random(rnd.Next(1000));
            Random rnd10 = new Random(rnd.Next(1000));
            Random rnd11 = new Random(rnd.Next(1000));
            Random rnd12 = new Random(rnd.Next(1000));
            Random rnd13 = new Random(rnd.Next(1000));
            Random rnd14 = new Random(rnd.Next(1000));
            Random rnd15 = new Random(rnd.Next(1000));
            Random rnd16 = new Random(rnd.Next(1000));
            /*double value1, value2, value3, value4,
                   value5, value6, value7, value8,
                   value9, value10, value11, value12,
                   value13, value14, value15, value16;*/

            //double[] values = new double[16];

            for (int i = 0; i < _stepsCount; i++)
            {
                bool value1 = rnd1.NextDouble() <= ToDouble(textBox1.Text);
                bool value2 = rnd2.NextDouble() <= ToDouble(textBox2.Text);
                bool value3 = rnd3.NextDouble() <= ToDouble(textBox3.Text);
                bool value4 = rnd4.NextDouble() <= ToDouble(textBox4.Text);
                bool value5 = rnd5.NextDouble() <= ToDouble(textBox5.Text);
                bool value6 = rnd6.NextDouble() <= ToDouble(textBox6.Text);
                bool value7 = rnd7.NextDouble() <= ToDouble(textBox7.Text);
                bool value8 = rnd8.NextDouble() <= ToDouble(textBox8.Text);
                bool value9 = rnd9.NextDouble() <= ToDouble(textBox9.Text);
                bool value10 = rnd10.NextDouble() <= ToDouble(textBox10.Text);
                bool value11 = rnd11.NextDouble() <= ToDouble(textBox11.Text);
                bool value12 = rnd12.NextDouble() <= ToDouble(textBox12.Text);
                bool value13 = rnd13.NextDouble() <= ToDouble(textBox13.Text);
                bool value14 = rnd14.NextDouble() <= ToDouble(textBox14.Text);
                bool value15 = rnd15.NextDouble() <= ToDouble(textBox15.Text);
                bool value16 = rnd16.NextDouble() <= ToDouble(textBox16.Text);

                bool blockFirst = (value1 & value2) || (value3 & value4);
                bool blockSecond = value5 || (value6 & value7) || value8;
                bool blockThird = value9 || (value10 & (value11 || value12));
                bool blockForth = value13 || (value14 || (value15 & value16));
                if ((blockFirst || blockThird) & (blockSecond || blockForth)) successCount++;
                /*for (int j = 0; j < 16; j++)
                {
                    Random rndValue = new Random(rnd.Next(1000));
                    values[j] = rndValue.NextDouble();
                }

                isSuccess =
                (values[0] <= ToDouble(textBox1.Text) || 
                (values[1] <= ToDouble(textBox2.Text)) || 
                (values[2] <= ToDouble(textBox3.Text)) || 
                (values[3] <= ToDouble(textBox4.Text)) ||
                (values[4] <= ToDouble(textBox5.Text)) || 
                (values[5] <= ToDouble(textBox6.Text)) || 
                (values[6] <= ToDouble(textBox7.Text)) || 
                (values[7] <= ToDouble(textBox8.Text)) ||
                (values[8] <= ToDouble(textBox9.Text)) || 
                (values[9] <= ToDouble(textBox10.Text)) || 
                (values[10] <= ToDouble(textBox11.Text)) || 
                (values[11] <= ToDouble(textBox12.Text)) ||
                (values[12] <= ToDouble(textBox13.Text)) || 
                (values[13] <= ToDouble(textBox14.Text)) || 
                (values[14] <= ToDouble(textBox15.Text)) || 
                (values[15] <= ToDouble(textBox16.Text)));
                if (isSuccess) successCount++;*/
            }
            // Вероятность в первом блоке
            _probabilityFirst = 1 - (1 - ToDouble(textBox1.Text) * ToDouble(textBox2.Text)) * (1 - ToDouble(textBox3.Text) * ToDouble(textBox4.Text));
            // Вероятность во втором блоке
            _probabilitySecond = (1 - (1 - ToDouble(textBox5.Text)) * (1 - ToDouble(textBox6.Text) * ToDouble((textBox7.Text)))) * ToDouble(textBox8.Text);
            // Вероятность в третьем блоке
            _probabilityThird = 1 - (1 - ToDouble(textBox9.Text)) * (1 - (1 - (1 - ToDouble(textBox11.Text)) * (1 - ToDouble(textBox12.Text)))* ToDouble(textBox10.Text));
            // Вероятность в четвертом блоке
            _probabilityForth = 1 - (1 - ToDouble(textBox13.Text)) * (1 - ToDouble(textBox14.Text)) * (1 - ToDouble(textBox15.Text) * ToDouble(textBox16.Text));
            // Общая вероятность
            _probabilityOverall = (1 - (1 - _probabilityFirst) * (1 - _probabilityThird)) * (1 - (1 - _probabilitySecond) * (1 - _probabilityForth));

            lb_resultProbability.Text = _probabilityOverall.ToString(); // Вывод общей вероятности
            lb_resultFrequency.Text = (successCount / _stepsCount).ToString();
        }

        // Метод для конвертирования вероятности в double, чтобы код выглядел компактней
        private double ToDouble(string tbText)
        {
            return Convert.ToDouble(tbText);
        }
    }
}
