﻿using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public ContactViewModel() { }

        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            _firstName = contact.FirstName;
            _lastName = contact.LastName;
            Phone = contact.Phone;
            Email = contact.Email;
            IsFavorite = contact.IsFavorite;
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName; 
            set
            {
                SetValue(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName; 
            set
            {
                SetValue(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _email;
        public string Email
        {
            get => _email; 
            set
            {
                SetValue(ref _email, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone; 
            set
            {
                SetValue(ref _phone, value);
            }
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite; 
            set
            {
                SetValue(ref _isFavorite, value);
                OnPropertyChanged(nameof(ProfileImage));
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public ImageSource ProfileImage
        {
            get
            {
                if (IsFavorite)
                {
                    return ImageSource.FromResource("ContactsApp.Assets.Images.FavoriteProfile.png");
                }
                return ImageSource.FromResource("ContactsApp.Assets.Images.NormalProfile.png");
            }
        }
    }
}
