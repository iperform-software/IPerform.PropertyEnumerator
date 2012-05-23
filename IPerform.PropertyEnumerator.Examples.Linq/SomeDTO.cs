using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IPerform.PropertyEnumerator.Examples.Basic
{
    [TableHeader("Beautiful {0} today", true)]
    class SomeDTO
    {
        [Display(Name = "Arrange Tourist Visa")]
        public bool ArrangeTouristVisa
        {
            get;
            set;
        }

        public bool ArrangeImmigrantVisa
        {
            get;
            set;
        }

        public bool ArrangeReciprocalVisa
        {
            get;
            set;
        }

        public bool ArrangeBusinessVisa
        {
            get;
            set;
        }

        public bool ArrangeTemporaryWorkingVisa
        {
            get;
            set;
        }

        public bool ArrangeWorkingPermit
        {
            get;
            set;
        }

        public bool ArrangeFamilyArrivalVisa
        {
            get;
            set;
        }

        public bool ArrangeResidencePermits
        {
            get;
            set;
        }

        public bool ArrangeExitVisa
        {
            get;
            set;
        }
    }
}
