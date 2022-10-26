﻿using DbService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Models {


    public class Discount {
        public DiscountBy DiscountBy { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }

        public override string ToString() {
            return $"DiscountBy: {DiscountBy}, Name: {Name}, Price: {Price}%";
        }

        public Discount(DiscountBy discountBy, string name, double price) {
            DiscountBy = discountBy;
            Name = name;
            Price = price;
        }

    }

    public class DiscountManager {

        public static DiscountManager DM { get; set; } = new DiscountManager();
        public ObservableCollection<Discount> AllDiscounts { get; set; } = new ObservableCollection<Discount>();
        JsonSave<Discount> LogDiscountsList = new JsonSave<Discount>("LogDiscountsList.json");

        private DiscountManager() {
            Load();
        }

        public void Save() {
            LogDiscountsList.SaveData(AllDiscounts);
        }
        public void Load() {
            AllDiscounts = new ObservableCollection<Discount>(LogDiscountsList.GetData());
        }
    }
}
