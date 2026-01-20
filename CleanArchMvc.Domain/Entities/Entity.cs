using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        DateTime createdDate { get; set; }
        DateTime? ModifiedDate { get; set;}
        string createdBy { get; set; }
        string modifiedBy { get; set; }
        }
    }
