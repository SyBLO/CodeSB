using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDT.Shared.Models
{
    public class SuiviBE
    {
        public int? SuiviBEId { get; set; }
        public string? Metier { get; set; }
        public string? ECR { get; set; }
        public string? ECO { get; set; }
        public string? FEE { get; set; }
        public string? Nadt { get; set; }
        public string? Prio { get; set; }
        public string? NivComplexe { get; set; }
        public DateTime? DfinP { get; set; }   // Deadline
        public DateTime? DfinR { get; set; }   // Achievement Date
        public DateTime? DValidFee { get; set; }
        public DateTime? Date { get; set; } //Initial Date
        public DateTime? DatePush { get; set; } // Push Date 
        [NotMapped]
        public string? CloseOn { get; private set; }
        public string? Statut {

            get
            {
                if (DatePush ==null)
                {
                    string var1;
                    var1 = "Open";
                    return var1;
                }
                else if (DatePush != null)
                {
                    string var2;
                    var2 = "Close";
                    return var2;
                }
                return CloseOn;
            }

            private set { }

        }
        public string? CodePrio { get; set; }
        public string? Description { get; set; }

       public List<ActionItem>? ActionItems { get; set; }
    }

   
 public class ActionItem
   {
        
        public int ActionId { get; set; }
        public string? Tilte { get; set; }
        public string? DescriptionA { get; set; }
        public string? State { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? CloseDate { get; set; }


        public int? SuiviBEId { get; set; }
        public SuiviBE? SuiviBE { get; set; }
    }

    public class Ressource
    {

    }
}
