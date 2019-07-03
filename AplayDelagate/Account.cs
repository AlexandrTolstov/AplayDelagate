using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplayDelagate
{
    class Account
    {
        public delegate void AccountStateHandler(object sender, AccountEventArgs e);
        public event AccountStateHandler Withdrawn;
        public event AccountStateHandler Added;
        int _sum;
        public Account(int sum)
        {
            _sum = sum;
        }
        public int CurrentSum
        {
            get { return _sum; }
        }
        public void Put(int sum)
        {
            _sum += sum;
            if (Added != null)
                Added(this, new AccountEventArgs($"На счет поступило {sum}", sum));
        }
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                if (Withdrawn != null)
                    Withdrawn(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
            }
            else
            {
                if (Withdrawn != null)
                    Withdrawn(this, new AccountEventArgs("Недостаточно денег на счете", sum));
            }
        }
    }
}
