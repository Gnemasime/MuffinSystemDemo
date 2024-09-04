using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuffinSystemDemo.Models
{
    public class Orders
    {
        //1
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNo { get; set; }
        public int ItemNo { get; set; }
        public virtual MuffinItems MuffinItems { get; set; }
        public string CustomerName { get; set; }
        public string Role { get; set; }
        public int NumMUffins { get; set; }
        public double DiscAmout { get; set; }
        public double VatAmout { get; set; }

        //3
        public double Pprice()
        {
            //NameofDbContext db = new NameofDbContext();
            AppDbContext db = new AppDbContext();
            var pri = (from p in db.items
                       where p.ItemNo == ItemNo
                       select p.Price).FirstOrDefault();
            return pri;
        }

        public double Vrate()
        {
            AppDbContext db = new AppDbContext();
            var vatt = (from r in db.items
                        where r.ItemNo == ItemNo
                        select r.VateRate).FirstOrDefault();
            return vatt;
        }

        public double Drate()
        {
            AppDbContext db = new AppDbContext();
            var vt = (from r in db.items
                        where r.ItemNo == ItemNo
                        select r.DiscRate).FirstOrDefault();
            return vt;
        }

        //4
        public double CalcBasicCost()
        {
            return Pprice() * NumMUffins;
        }

        //5
        public double CalcDiscAmt()
        {
            double discrate = Drate();
            double disc;
            double basic = CalcBasicCost();

            if(Role == "Staff" && NumMUffins > 5) 
            {
                disc = ((discrate * 0.25) + discrate) + basic;
            }
            else if (Role == "Student" && NumMUffins > 3)
            {
                disc = ((discrate * 0.5) + discrate) * basic;
            }
            else
            {
                disc = 0;
            }

            return disc;
        }


    }
}