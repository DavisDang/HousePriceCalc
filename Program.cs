using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int housePrice = 3330000;
            Console.WriteLine("房屋售价：" + housePrice);
            int downpayment = 1320000;
            Console.WriteLine("首付总额：" + downpayment);
            int rentPrice = 7000;
            Console.WriteLine("租赁价格：" + rentPrice);
            int payments = 11721;
            Console.WriteLine("月供：" + payments);
            int monthAll = 300;
            Console.WriteLine("房贷总月份：" + monthAll);
            double rate_ROI = 0.1;
            Console.WriteLine("年化投资收益率：" + rate_ROI);
            double rate_HouseValue = 0.05;
            Console.WriteLine("房价年化涨幅：" + rate_HouseValue);
            double rate_Discount = 0.04;
            Console.WriteLine("折现率：" + rate_Discount);
            Console.WriteLine("租售比为1：" + housePrice / rentPrice);

            int monthCount = 60;
            double assets_House = housePrice * Math.Pow((1 + rate_HouseValue/12),monthCount);//房屋资产
            double liabilities = 0;//负债折现到当月
            for (int i = monthCount; i < monthAll; i++)
            {
                liabilities += payments / (Math.Pow(1+rate_Discount/12, i - monthCount+1));
            }
            double assets_Net_House = assets_House - liabilities;
            Console.WriteLine(monthCount+"个月后：");
            Console.WriteLine("1>选择购房方案形成当年净资产;"+ assets_Net_House);

            double assets_Invest = downpayment * Math.Pow(1 + rate_ROI/12, monthCount);//首付投资形成资产
            double assets_Increase_Invest = 0;//原本用于月供的钱，付房租后剩余的钱产生的收益
            for(int i = 1; i <=monthCount; i++)
            {             
                if (payments - rentPrice * (Math.Pow(1 + rate_HouseValue / 12, i)) < 0)//房租涨幅同房价涨幅，房租超过月供后，此后房租=月供
                {
                    assets_Increase_Invest += 0;
                }
                else
                    assets_Increase_Invest += (payments - rentPrice * (Math.Pow(1 + rate_HouseValue / 12, i))) * Math.Pow(1 + rate_ROI / 12, i - 1);
            }
            double assets_Net_Invest = assets_Invest + assets_Increase_Invest;
            Console.WriteLine("2>租赁投资方案形成当年净资产;" + assets_Net_Invest);          
            Console.ReadLine();
        }
    }
}
