using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RN.MOBILE_COMMON
{

    public class PolicyCover
    {
        public string policyType { get; set; }
        public string SumInsured { get; set; }
        public string WPonPolicy { get; set; }
        public string BSI { get; set; }
        public int HideCntInsured { get; set; }
        public int HideTariff { get; set; }
        [Ignore]
        public List<maxClaim> lstMaxclaim { get; set; }
        [Ignore]
        public List<RelapsedPeriod> lstRP { get; set; }
        [Ignore]
        public List<WPonAilment> lstWPAilment { get; set; }
        [Ignore]
        public List<CoPay> lstCopay { get; set; }
        [Ignore]
        public List<InclusionAil> lstInclusionAilment { get; set; }
        [Ignore]
        public List<ExClusionAil> lstExclusionAilment { get; set; }
        [Ignore]
        public List<InclusionAilDiag> lstIncluAilDiag { get; set; }
        [Ignore]
        public List<InclusionAilDrug> lstIncluAilDrug { get; set; }
        [Ignore]
        public List<InclusionHealthChk> lstIncluHC { get; set; }
        [Ignore]
        public List<ExClusionHealthChk> lstExclusionHC { get; set; }
        [Ignore]
        public List<MaxClaimAmt> lstMaxClaimAmt { get; set; }
        [Ignore]
        public List<maxClaim> lstMaxClaimPerDay { get; set; }
        [Ignore]
        public List<MaxClaimAmt> lstMaxClailAmtPerDay { get; set; }
        [Ignore]
        public List<ExClusionPharDrug> lstExClusionPharDrug { get; set; }
        [Ignore]
        public List<ExClusionDiagnostic> lstExClusionDiagnostic { get; set; }
        [Ignore]
        public List<ExClusionDiagnosticGroup> lstExClusionDiagnosticGroup { get; set; }
        [Ignore]
        public List<ExClusionAilDiag> lstExClusionAilDiag { get; set; }
        [Ignore]
        public List<ExClusionAilDiagGroup> lstExClusionAilDiagGroup { get; set; }
        [Ignore]
        public List<ExClusionAilDrug> lstExClusionAilDrug { get; set; }
        [Ignore]
        public List<ExClusionAilPro> lstExClusionAilPro { get; set; }
        [Ignore]
        public List<ExcluMinorPro> lstExcluMinorPro { get; set; }
        [Ignore]
        public List<CoPayOnRelation> lstCoPayOnRelation { get; set; }
        [Ignore]
        public List<CoPayOnAge> lstCoPayOnAge { get; set; }
        [Ignore]
        public List<DeductionOnHome> lstDeductionOnHome { get; set; }
        [Ignore]
        public List<DeductionOnPhysical> lstDeductionOnPhysical { get; set; }


        public string WatingPeroidOnPolicy { get; set; }      
       
        public string Serialize()
        {
            using (var sww = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(this.GetType());
                    xsSubmit.Serialize(writer, this);
                    return sww.ToString();
                }
            }
        }
        
        public PolicyCover DeSerialize(string inputString)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringReader rdr = new StringReader(inputString))
            {
                return (PolicyCover)serializer.Deserialize(rdr);
            }
        }
    }

    public class MaxClaimAmt
    {
        public string service { get; set; }
        public string maxClaimAmt { get; set; }
        public string availClaimAmt { get; set; }
    }

    public class MaxClaimAmtPerDay
    {
        public string service { get; set; }
        public string maxClaimAmt { get; set; }
        public string availClaimAmt { get; set; }
    }

    public class maxClaim
    {
        public string Service { get; set; }
        public string MaxClaim { get; set; }
        public string AvailClaim { get; set; }       
    }

    public class maxclaimPerday
    {
        public string Service { get; set; }
        public string MaxClaim { get; set; }
        public string AvailClaim { get; set; }
    }

    public class RelapsedPeriod
    {
        public string Service { get; set; }
        public string RPDays { get; set; }
    }

    public class WPonAilment
    {
        public string AilmentName { get; set; }
        public string WPDays { get; set; }
        public string period_type { get; set; }
    }

    public class CoPay
    {
        public string ServiceName { get; set; }
        public string AppOn { get; set; }
        public string PerCent { get; set; }
    }

    public class InclusionAil
    {
        public string AilmentName { get; set; }
    }

    public class InclusionAilDiag
    {
        public string AilmentName { get; set; }
        public string DiagnosticName { get; set; }
    }


    public class InclusionAilDrug
    {
        public string AilmentName { get; set; }
        public string DurgName { get; set; }
    }

    public class InclusionHealthChk
    {
        public string HealthChkName { get; set; }
    }

    public class ExClusionAil
    {
        public string AilmentName { get; set; }
    }

    public class ExClusionAilDiag
    {
        public string AilmentID { get; set; }
        public string AilmentName { get; set; }

    }

    public class ExClusionAilDiagGroup
    {
        public string AilmentCode { get; set; }
        public string AilmentName { get; set; }

    }

    public class ExClusionAilDrug
    {
        public string AilmentName { get; set; }
        public string AilmentCode { get; set; }
    }
    public class ExClusionAilPro
    {
        public string AilmentName { get; set; }
        public string AilmentCode { get; set; }
    }

    public class ExClusionHealthChk
    {
        public string HealthChkName { get; set; }
    }

    public class ExClusionPharDrug
    {
        public string Code { get; set; }
        public string DurgName { get; set; }
    }

    public class ExClusionDiagnostic
    {
        public string DiagnosticName { get; set; }
    }
    public class ExClusionDiagnosticGroup
    {
        public string DiagnosticGroupCode { get; set; }
        public string DiagnosticGroupName { get; set; }
    }
    public class ExcluMinorPro
    {
        public string ProcedureName { get; set; }

    }

    public class CoPayOnRelation
    {
        public string Relationship { get; set; }
        public string Percentage { get; set; }
        public string Flat { get; set; }
    }

    public class CoPayOnAge
    {
        public string AgeMin { get; set; }
        public string AgeMax { get; set; }
        public string Percentage { get; set; }
        public string Flat { get; set; }
    }
    public class DeductionOnHome
    {
        public string ServiceType { get; set; }
        public string MaxLimit { get; set; }
        public string Percentage { get; set; }
        public string Flat { get; set; }
    }
    public class DeductionOnPhysical
    {
        public string ServiceType { get; set; }
        public string MaxLimit { get; set; }
        public string Percentage { get; set; }
        public string Flat { get; set; }
    }

    public class TeleConsultUtilization
    {
        public string Teleconsult_Count_Config { get; set; }
        public string Teleconsult_Utilized { get; set; }
        public string Teleconsult_Available { get; set; }

        public string Serialize()
        {
            using (var sww = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(this.GetType());
                    xsSubmit.Serialize(writer, this);
                    return sww.ToString();
                }
            }
        }

        public TeleConsultUtilization DeSerialize(string inputString)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringReader rdr = new StringReader(inputString))
            {
                return (TeleConsultUtilization)serializer.Deserialize(rdr);
            }
        }
    }

    public class GetPolicyCoverGroupItems
    {
        public string Serialize()
        {
            using (var sww = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(this.GetType());
                    xsSubmit.Serialize(writer, this);
                    return sww.ToString();
                }
            }
        }

        public GetPolicyCoverGroupItems DeSerialize(string inputString)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringReader rdr = new StringReader(inputString))
            {
                return (GetPolicyCoverGroupItems)serializer.Deserialize(rdr);
            }
        }
        public List<string> ITEMNAME { get; set; }
    }

    public class GetPolicyType
    {
        public string PolicyType { get; set; }
        public string MemberNo { get; set; }

        public string Policy_Number { get; set; }

        public string Serialize()
        {
            using (var sww = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(this.GetType());
                    xsSubmit.Serialize(writer, this);
                    return sww.ToString();
                }
            }
        }

        public GetPolicyType DeSerialize(string inputString)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringReader rdr = new StringReader(inputString))
            {
                return (GetPolicyType)serializer.Deserialize(rdr);
            }
        }

    }


    #region Benefit Utilization DashBoard

    public class BenefitDashB
    {
        public string BenefitType { get; set; }
        public string TotalCnt { get; set; }
        public string UtilizedCnt { get; set; }
        public string BalanceCnt { get; set; }
        public string TotalAmt { get; set; }
        public string UtilizedAmt { get; set; }
        public string BalanceAmt { get; set; }
        public Int32 transType { get; set; }

        public string ItemName { get; set; }
    }

    public class BenefitList
    {
        public string Header { get; set; }
        public string SI { get; set; }
        public string BSI { get; set; }
        [Ignore]
        public List<BenefitDashB> lstBenefit { get; set; }
        [Ignore]
        public ItemWiseBenefit objItemBenefit { get; set; }
        public Int32 transType { get; set; }
        public int HideCntInsured { get; set; }
        public int HideTariff { get; set; }
    }
    public class ItemWiseBenefit
    {
        public string Header { get; set; }
        public List<BenefitDashB> lstItem{ get; set; }
    }
    #endregion
}

