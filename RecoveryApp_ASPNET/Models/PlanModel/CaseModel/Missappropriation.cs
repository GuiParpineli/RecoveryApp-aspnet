using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models.PlanModel.CaseModel
{
    public class Missappropriation : CaseRecovery
    {
        [Key]
        public override long Id { get; set; }
        public override DateTime Date { get; set; }
        public override string Stage { get;  set; }
        public override double Value { get; set; }
        public override double CoverageValue { get; set ; }
        public override string? PostCode { get; set; }
        public override string? Observation { get; set; }
        public override string? CaseType { get; set; }


        public string PayMethod { get; set; }
        public bool ChargeBack { get; set; }
        public DateTime ChargeBackDate { get; set; }
    }
}
