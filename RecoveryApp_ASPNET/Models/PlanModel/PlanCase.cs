using RecoveryApp_ASPNET.Models.PlanModel.CaseModel;

namespace RecoveryApp_ASPNET.Models.PlanModel
{
    public class PlanCase
    {
        public Guid PlanId { get; set; }
        public Plan Plan { get; set; }
        
        public Guid CaseId { get; set; }
        public CaseRecovery? CaseRecovery { get; set; }
    }
}
