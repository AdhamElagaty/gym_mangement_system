using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class PackgeSubscriptionModel : SubscriptionModel<PackgeModel>
    {
        private int remainInvatation;
        private PackgeModel packgeModel;
        private MonthOfferModel monthOffer;
        private List<ClassModel> classes;

        public PackgeSubscriptionModel(int id = 0, int numOfAttend = 0, DateTime startDate = default, DateTime endDate = default, MemberModel member = null, EmployeeModel employee = null,int remainInvatation = 0, PackgeModel packgeModel = null, MonthOfferModel monthOffer = null, List<ClassModel> classes = null) : base(id, numOfAttend, startDate, endDate, member, employee)
        { 
            PackgeModel = packgeModel;
            MonthOffer = monthOffer;
            Classes = classes;
            RemainInvatation = remainInvatation;

        }

        public int RemainInvatation { get { return remainInvatation; } set { remainInvatation = value; } }
        public PackgeModel PackgeModel { get { return packgeModel; } set { packgeModel = value; } }
        public MonthOfferModel MonthOffer { get { return monthOffer; } set { monthOffer = value; } }
        public List<ClassModel> Classes { get {  return classes; } set { classes = value; } }
        public int PackgeModelId { get { return packgeModel.Id; } }
        public string PackgeModelName { get { return packgeModel.Name; } }

        public override PackgeModel getDataOfTybeOfSubscription()
        {
            return packgeModel;
        }
    }
}
