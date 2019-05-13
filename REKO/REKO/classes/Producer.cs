﻿using System;
using System.Collections.Generic;
using System.Text;

namespace REKO
{
    public class Producer
    {
        String name, description, rekoRing;
        int id;

        public Producer(String name, String description, int id, String rekoRing)
        {
            this.name = name;
            this.description = description;
            this.id = id;
            this.rekoRing = rekoRing;
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string RekoRing
        {
            get
            {
                return rekoRing;
            }
            set
            {
                rekoRing = value;
            }
        }


        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
