using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        // Генерация рандомных чисел
        Random randomizer = new Random();
        // Переменные
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }
        public void StartTheQuiz()
        {
            // Два числа (сложение)
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Преобразуем рандомные числа в строки
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            // Два числа (вычитание)
            minuend = randomizer.Next(10, 99);
            subtrahend = randomizer.Next(9, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Два числа (умножение)
            multiplicand = randomizer.Next(3, 11);
            multiplier = randomizer.Next(3, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Два числа (деление)
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Запуск таймера
            timeLeft = 35;
            timeLabel.Text = "35 секунд";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // Если пользователь ответит правильно на вопросы, то отсановится таймер и выведется окно "Выигрыш"
                timer1.Stop();
                MessageBox.Show("Отлично, ты справился.",
                                "Поздравления!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Отсчет времени
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " секунд";
            }
            else
            {
                // Если таймер пройдет, выведется окно "Проигрыш", также в окне для ответов появятся правильные ответы
                timer1.Stop();
                timeLabel.Text = "Время закончилось:(";
                MessageBox.Show("Ты не успел.", "Эх-эх-эхушки...");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.Show();
        }
    }
}
