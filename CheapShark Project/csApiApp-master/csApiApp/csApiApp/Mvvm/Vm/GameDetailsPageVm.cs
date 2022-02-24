﻿using csApiApp.Models;
using csApiApp.Services.Rest;
using csApiApp.Services;
using FunctionZero.MvvmZero;
using Xamarin.Forms;
using System;
using System.Windows.Input;

namespace csApiApp.Mvvm.Vm
{
    public class GameDetailsPageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;
        private readonly CheapSharkAPI _cheapSharkAPI;

        public string _reviewUrl;
        public string ReviewUrl
        {
            get => _reviewUrl;
            set
            {
                _reviewUrl = value;
                OnPropertyChanged();
            }
        }
        private bool _linkVisibility;
        public bool LinkVisibility
        {
            get => _linkVisibility;
            set
            {
                _linkVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand TapCommand
        {
            get
            {
                return new Command(() =>
                {
                    OpenBrowser();
                });
            }
        }

        private Store _dealStore;

        public DealResult DealResult
        {
            get => _dealResult;
            set => base.SetProperty(ref _dealResult, value);
        }

        public Store DealStore
        {
            get => _dealStore;
            set => base.SetProperty(ref _dealStore, value);
        }
        public object MetaReviewLabel { get; private set; }

        public GameDetailsPageVm(CheapSharkAPI cheapSharkAPI, IPageServiceZero pageService, SQLiteInterface sqliteInterface) : base(pageService, cheapSharkAPI, sqliteInterface)
        {
            _pageService = pageService;
            _cheapSharkAPI = cheapSharkAPI;
        }

        internal void Init(string searchText, DealResult dealResult)
        {
            base.Init(searchText);
            DealResult = dealResult;

            int storeId = int.Parse(DealResult.StoreID);

            foreach (Store store in StoreList)
            {
                if (store.StoreID == storeId)
                {
                    DealStore = store;
                }
            }

            if (DealResult.MetaReviewLink != null)
            {
                ReviewUrl = "https://www.metacritic.com" + DealResult.MetaReviewLink;
                LinkVisibility = true;
            }
            else
            {
                LinkVisibility = false;
            }
            
        }

        void OpenBrowser()
        {
            Device.OpenUri(new Uri(ReviewUrl));
        }
    }
}