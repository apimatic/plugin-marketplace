using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The business industry classification.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BusinessIndustry>))]
public sealed record BusinessIndustry : OpenStringEnum<BusinessIndustry>
{
    private BusinessIndustry(string value) : base(value)
    {
    }

    public static readonly BusinessIndustry AccommodationAndHospitality = new("ACCOMMODATION_AND_HOSPITALITY");

    public static readonly BusinessIndustry AccommodationAndHospitalityTimesharing = new(
        "ACCOMMODATION_AND_HOSPITALITY_TIMESHARING");

    public static readonly BusinessIndustry AdminAndSupportServices = new("ADMIN_AND_SUPPORT_SERVICES");

    public static readonly BusinessIndustry AdminAndSupportServicesCleaningAndFacilities = new(
        "ADMIN_AND_SUPPORT_SERVICES_CLEANING_AND_FACILITIES");

    public static readonly BusinessIndustry AdminAndSupportServicesSecurityAndInvestigation = new(
        "ADMIN_AND_SUPPORT_SERVICES_SECURITY_AND_INVESTIGATION");

    public static readonly BusinessIndustry AdminAndSupportServicesSpecificSectors = new(
        "ADMIN_AND_SUPPORT_SERVICES_SPECIFIC_SECTORS");

    public static readonly BusinessIndustry AgricultureForestryAndFishing = new("AGRICULTURE_FORESTRY_AND_FISHING");

    public static readonly BusinessIndustry Construction = new("CONSTRUCTION");

    public static readonly BusinessIndustry Education = new("EDUCATION");

    public static readonly BusinessIndustry EducationHigherEducation = new("EDUCATION_HIGHER_EDUCATION");

    public static readonly BusinessIndustry EntertainmentArtsAndRecreation = new("ENTERTAINMENT_ARTS_AND_RECREATION");

    public static readonly BusinessIndustry EntertainmentArtsAndRecreationNatureAndZoos = new(
        "ENTERTAINMENT_ARTS_AND_RECREATION_NATURE_AND_ZOOS");

    public static readonly BusinessIndustry EntertainmentArtsAndRecreationSpecificSectors = new(
        "ENTERTAINMENT_ARTS_AND_RECREATION_SPECIFIC_SECTORS");

    public static readonly BusinessIndustry ExtraterritorialAndHouseholdActivities = new(
        "EXTRATERRITORIAL_AND_HOUSEHOLD_ACTIVITIES");

    public static readonly BusinessIndustry FinancialServices = new("FINANCIAL_SERVICES");

    public static readonly BusinessIndustry FinancialServicesOthersAndInsurance = new(
        "FINANCIAL_SERVICES_OTHERS_AND_INSURANCE");

    public static readonly BusinessIndustry FoodAndBeverageServices = new("FOOD_AND_BEVERAGE_SERVICES");

    public static readonly BusinessIndustry Healthcare = new("HEALTHCARE");

    public static readonly BusinessIndustry HealthcareCounsellingAndSocialServices = new(
        "HEALTHCARE_COUNSELLING_AND_SOCIAL_SERVICES");

    public static readonly BusinessIndustry InformationTechnologyAndMedia = new("INFORMATION_TECHNOLOGY_AND_MEDIA");

    public static readonly BusinessIndustry InformationTechnologyAndMediaOnlineGaming = new(
        "INFORMATION_TECHNOLOGY_AND_MEDIA_ONLINE_GAMING");

    public static readonly BusinessIndustry InformationTechnologyAndMediaPrintPublishing = new(
        "INFORMATION_TECHNOLOGY_AND_MEDIA_PRINT_PUBLISHING");

    public static readonly BusinessIndustry InformationTechnologyAndMediaTelecommunications = new(
        "INFORMATION_TECHNOLOGY_AND_MEDIA_TELECOMMUNICATIONS");

    public static readonly BusinessIndustry Manufacturing = new("MANUFACTURING");

    public static readonly BusinessIndustry ManufacturingPharmaceuticals = new("MANUFACTURING_PHARMACEUTICALS");

    public static readonly BusinessIndustry ManufacturingPreciousMetalsAndJewellery = new(
        "MANUFACTURING_PRECIOUS_METALS_AND_JEWELLERY");

    public static readonly BusinessIndustry ManufacturingWeaponsAndHazardous = new(
        "MANUFACTURING_WEAPONS_AND_HAZARDOUS");

    public static readonly BusinessIndustry MiningAndQuarrying = new("MINING_AND_QUARRYING");

    public static readonly BusinessIndustry PersonalAndOtherServices = new("PERSONAL_AND_OTHER_SERVICES");

    public static readonly BusinessIndustry PersonalAndOtherServicesAdultAndWellness = new(
        "PERSONAL_AND_OTHER_SERVICES_ADULT_AND_WELLNESS");

    public static readonly BusinessIndustry PersonalAndOtherServicesNonprofitAndMembershipOrganisations = new(
        "PERSONAL_AND_OTHER_SERVICES_NONPROFIT_AND_MEMBERSHIP_ORGANISATIONS");

    public static readonly BusinessIndustry ProfessionalAndTechnicalServices = new(
        "PROFESSIONAL_AND_TECHNICAL_SERVICES");

    public static readonly BusinessIndustry ProfessionalAndTechnicalServicesLegalAndFiduciary = new(
        "PROFESSIONAL_AND_TECHNICAL_SERVICES_LEGAL_AND_FIDUCIARY");

    public static readonly BusinessIndustry ProfessionalAndTechnicalServicesUnregulated = new(
        "PROFESSIONAL_AND_TECHNICAL_SERVICES_UNREGULATED");

    public static readonly BusinessIndustry PublicAdministration = new("PUBLIC_ADMINISTRATION");

    public static readonly BusinessIndustry PublicAdministrationJudicial = new("PUBLIC_ADMINISTRATION_JUDICIAL");

    public static readonly BusinessIndustry RealEstate = new("REAL_ESTATE");

    public static readonly BusinessIndustry RealEstateAgencyAndBrokerage = new("REAL_ESTATE_AGENCY_AND_BROKERAGE");

    public static readonly BusinessIndustry RetailTrade = new("RETAIL_TRADE");

    public static readonly BusinessIndustry RetailTradeSpeciality = new("RETAIL_TRADE_SPECIALITY");

    public static readonly BusinessIndustry RetailTradeSpecificSectors = new("RETAIL_TRADE_SPECIFIC_SECTORS");

    public static readonly BusinessIndustry TransportationAndLogistics = new("TRANSPORTATION_AND_LOGISTICS");

    public static readonly BusinessIndustry TransportationAndLogisticsCruiseLines = new(
        "TRANSPORTATION_AND_LOGISTICS_CRUISE_LINES");

    public static readonly BusinessIndustry TransportationAndLogisticsRailAndStorage = new(
        "TRANSPORTATION_AND_LOGISTICS_RAIL_AND_STORAGE");

    public static readonly BusinessIndustry UtilitiesAndEnergy = new("UTILITIES_AND_ENERGY");

    public static readonly BusinessIndustry WholesaleTrade = new("WHOLESALE_TRADE");

    public static readonly BusinessIndustry WholesaleTradeIndustrial = new("WHOLESALE_TRADE_INDUSTRIAL");

    public static readonly BusinessIndustry WholesaleTradeLuxuryAndCollectibles = new(
        "WHOLESALE_TRADE_LUXURY_AND_COLLECTIBLES");

    public static readonly BusinessIndustry WholesaleTradePetroleumAndChemicals = new(
        "WHOLESALE_TRADE_PETROLEUM_AND_CHEMICALS");

    public TResult Match<TResult>(Func<TResult> onAccommodationAndHospitality,
        Func<TResult> onAccommodationAndHospitalityTimesharing,
        Func<TResult> onAdminAndSupportServices,
        Func<TResult> onAdminAndSupportServicesCleaningAndFacilities,
        Func<TResult> onAdminAndSupportServicesSecurityAndInvestigation,
        Func<TResult> onAdminAndSupportServicesSpecificSectors,
        Func<TResult> onAgricultureForestryAndFishing,
        Func<TResult> onConstruction,
        Func<TResult> onEducation,
        Func<TResult> onEducationHigherEducation,
        Func<TResult> onEntertainmentArtsAndRecreation,
        Func<TResult> onEntertainmentArtsAndRecreationNatureAndZoos,
        Func<TResult> onEntertainmentArtsAndRecreationSpecificSectors,
        Func<TResult> onExtraterritorialAndHouseholdActivities,
        Func<TResult> onFinancialServices,
        Func<TResult> onFinancialServicesOthersAndInsurance,
        Func<TResult> onFoodAndBeverageServices,
        Func<TResult> onHealthcare,
        Func<TResult> onHealthcareCounsellingAndSocialServices,
        Func<TResult> onInformationTechnologyAndMedia,
        Func<TResult> onInformationTechnologyAndMediaOnlineGaming,
        Func<TResult> onInformationTechnologyAndMediaPrintPublishing,
        Func<TResult> onInformationTechnologyAndMediaTelecommunications,
        Func<TResult> onManufacturing,
        Func<TResult> onManufacturingPharmaceuticals,
        Func<TResult> onManufacturingPreciousMetalsAndJewellery,
        Func<TResult> onManufacturingWeaponsAndHazardous,
        Func<TResult> onMiningAndQuarrying,
        Func<TResult> onPersonalAndOtherServices,
        Func<TResult> onPersonalAndOtherServicesAdultAndWellness,
        Func<TResult> onPersonalAndOtherServicesNonprofitAndMembershipOrganisations,
        Func<TResult> onProfessionalAndTechnicalServices,
        Func<TResult> onProfessionalAndTechnicalServicesLegalAndFiduciary,
        Func<TResult> onProfessionalAndTechnicalServicesUnregulated,
        Func<TResult> onPublicAdministration,
        Func<TResult> onPublicAdministrationJudicial,
        Func<TResult> onRealEstate,
        Func<TResult> onRealEstateAgencyAndBrokerage,
        Func<TResult> onRetailTrade,
        Func<TResult> onRetailTradeSpeciality,
        Func<TResult> onRetailTradeSpecificSectors,
        Func<TResult> onTransportationAndLogistics,
        Func<TResult> onTransportationAndLogisticsCruiseLines,
        Func<TResult> onTransportationAndLogisticsRailAndStorage,
        Func<TResult> onUtilitiesAndEnergy,
        Func<TResult> onWholesaleTrade,
        Func<TResult> onWholesaleTradeIndustrial,
        Func<TResult> onWholesaleTradeLuxuryAndCollectibles,
        Func<TResult> onWholesaleTradePetroleumAndChemicals,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccommodationAndHospitality => onAccommodationAndHospitality(),
            _ when this == AccommodationAndHospitalityTimesharing => onAccommodationAndHospitalityTimesharing(),
            _ when this == AdminAndSupportServices => onAdminAndSupportServices(),
            _ when this ==
                AdminAndSupportServicesCleaningAndFacilities => onAdminAndSupportServicesCleaningAndFacilities(),
            _ when this ==
                AdminAndSupportServicesSecurityAndInvestigation => onAdminAndSupportServicesSecurityAndInvestigation(),
            _ when this == AdminAndSupportServicesSpecificSectors => onAdminAndSupportServicesSpecificSectors(),
            _ when this == AgricultureForestryAndFishing => onAgricultureForestryAndFishing(),
            _ when this == Construction => onConstruction(),
            _ when this == Education => onEducation(),
            _ when this == EducationHigherEducation => onEducationHigherEducation(),
            _ when this == EntertainmentArtsAndRecreation => onEntertainmentArtsAndRecreation(),
            _ when this ==
                EntertainmentArtsAndRecreationNatureAndZoos => onEntertainmentArtsAndRecreationNatureAndZoos(),
            _ when this ==
                EntertainmentArtsAndRecreationSpecificSectors => onEntertainmentArtsAndRecreationSpecificSectors(),
            _ when this == ExtraterritorialAndHouseholdActivities => onExtraterritorialAndHouseholdActivities(),
            _ when this == FinancialServices => onFinancialServices(),
            _ when this == FinancialServicesOthersAndInsurance => onFinancialServicesOthersAndInsurance(),
            _ when this == FoodAndBeverageServices => onFoodAndBeverageServices(),
            _ when this == Healthcare => onHealthcare(),
            _ when this == HealthcareCounsellingAndSocialServices => onHealthcareCounsellingAndSocialServices(),
            _ when this == InformationTechnologyAndMedia => onInformationTechnologyAndMedia(),
            _ when this == InformationTechnologyAndMediaOnlineGaming => onInformationTechnologyAndMediaOnlineGaming(),
            _ when this ==
                InformationTechnologyAndMediaPrintPublishing => onInformationTechnologyAndMediaPrintPublishing(),
            _ when this ==
                InformationTechnologyAndMediaTelecommunications => onInformationTechnologyAndMediaTelecommunications(),
            _ when this == Manufacturing => onManufacturing(),
            _ when this == ManufacturingPharmaceuticals => onManufacturingPharmaceuticals(),
            _ when this == ManufacturingPreciousMetalsAndJewellery => onManufacturingPreciousMetalsAndJewellery(),
            _ when this == ManufacturingWeaponsAndHazardous => onManufacturingWeaponsAndHazardous(),
            _ when this == MiningAndQuarrying => onMiningAndQuarrying(),
            _ when this == PersonalAndOtherServices => onPersonalAndOtherServices(),
            _ when this == PersonalAndOtherServicesAdultAndWellness => onPersonalAndOtherServicesAdultAndWellness(),
            _ when this ==
                PersonalAndOtherServicesNonprofitAndMembershipOrganisations => onPersonalAndOtherServicesNonprofitAndMembershipOrganisations(),
            _ when this == ProfessionalAndTechnicalServices => onProfessionalAndTechnicalServices(),
            _ when this ==
                ProfessionalAndTechnicalServicesLegalAndFiduciary => onProfessionalAndTechnicalServicesLegalAndFiduciary(),
            _ when this ==
                ProfessionalAndTechnicalServicesUnregulated => onProfessionalAndTechnicalServicesUnregulated(),
            _ when this == PublicAdministration => onPublicAdministration(),
            _ when this == PublicAdministrationJudicial => onPublicAdministrationJudicial(),
            _ when this == RealEstate => onRealEstate(),
            _ when this == RealEstateAgencyAndBrokerage => onRealEstateAgencyAndBrokerage(),
            _ when this == RetailTrade => onRetailTrade(),
            _ when this == RetailTradeSpeciality => onRetailTradeSpeciality(),
            _ when this == RetailTradeSpecificSectors => onRetailTradeSpecificSectors(),
            _ when this == TransportationAndLogistics => onTransportationAndLogistics(),
            _ when this == TransportationAndLogisticsCruiseLines => onTransportationAndLogisticsCruiseLines(),
            _ when this == TransportationAndLogisticsRailAndStorage => onTransportationAndLogisticsRailAndStorage(),
            _ when this == UtilitiesAndEnergy => onUtilitiesAndEnergy(),
            _ when this == WholesaleTrade => onWholesaleTrade(),
            _ when this == WholesaleTradeIndustrial => onWholesaleTradeIndustrial(),
            _ when this == WholesaleTradeLuxuryAndCollectibles => onWholesaleTradeLuxuryAndCollectibles(),
            _ when this == WholesaleTradePetroleumAndChemicals => onWholesaleTradePetroleumAndChemicals(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccommodationAndHospitality,
        Action onAccommodationAndHospitalityTimesharing,
        Action onAdminAndSupportServices,
        Action onAdminAndSupportServicesCleaningAndFacilities,
        Action onAdminAndSupportServicesSecurityAndInvestigation,
        Action onAdminAndSupportServicesSpecificSectors,
        Action onAgricultureForestryAndFishing,
        Action onConstruction,
        Action onEducation,
        Action onEducationHigherEducation,
        Action onEntertainmentArtsAndRecreation,
        Action onEntertainmentArtsAndRecreationNatureAndZoos,
        Action onEntertainmentArtsAndRecreationSpecificSectors,
        Action onExtraterritorialAndHouseholdActivities,
        Action onFinancialServices,
        Action onFinancialServicesOthersAndInsurance,
        Action onFoodAndBeverageServices,
        Action onHealthcare,
        Action onHealthcareCounsellingAndSocialServices,
        Action onInformationTechnologyAndMedia,
        Action onInformationTechnologyAndMediaOnlineGaming,
        Action onInformationTechnologyAndMediaPrintPublishing,
        Action onInformationTechnologyAndMediaTelecommunications,
        Action onManufacturing,
        Action onManufacturingPharmaceuticals,
        Action onManufacturingPreciousMetalsAndJewellery,
        Action onManufacturingWeaponsAndHazardous,
        Action onMiningAndQuarrying,
        Action onPersonalAndOtherServices,
        Action onPersonalAndOtherServicesAdultAndWellness,
        Action onPersonalAndOtherServicesNonprofitAndMembershipOrganisations,
        Action onProfessionalAndTechnicalServices,
        Action onProfessionalAndTechnicalServicesLegalAndFiduciary,
        Action onProfessionalAndTechnicalServicesUnregulated,
        Action onPublicAdministration,
        Action onPublicAdministrationJudicial,
        Action onRealEstate,
        Action onRealEstateAgencyAndBrokerage,
        Action onRetailTrade,
        Action onRetailTradeSpeciality,
        Action onRetailTradeSpecificSectors,
        Action onTransportationAndLogistics,
        Action onTransportationAndLogisticsCruiseLines,
        Action onTransportationAndLogisticsRailAndStorage,
        Action onUtilitiesAndEnergy,
        Action onWholesaleTrade,
        Action onWholesaleTradeIndustrial,
        Action onWholesaleTradeLuxuryAndCollectibles,
        Action onWholesaleTradePetroleumAndChemicals,
        Action<string> otherwise)
    {
        if (this == AccommodationAndHospitality) onAccommodationAndHospitality();
        else if (this == AccommodationAndHospitalityTimesharing) onAccommodationAndHospitalityTimesharing();
        else if (this == AdminAndSupportServices) onAdminAndSupportServices();
        else if (this == AdminAndSupportServicesCleaningAndFacilities) onAdminAndSupportServicesCleaningAndFacilities();
        else if (this ==
            AdminAndSupportServicesSecurityAndInvestigation) onAdminAndSupportServicesSecurityAndInvestigation();
        else if (this == AdminAndSupportServicesSpecificSectors) onAdminAndSupportServicesSpecificSectors();
        else if (this == AgricultureForestryAndFishing) onAgricultureForestryAndFishing();
        else if (this == Construction) onConstruction();
        else if (this == Education) onEducation();
        else if (this == EducationHigherEducation) onEducationHigherEducation();
        else if (this == EntertainmentArtsAndRecreation) onEntertainmentArtsAndRecreation();
        else if (this == EntertainmentArtsAndRecreationNatureAndZoos) onEntertainmentArtsAndRecreationNatureAndZoos();
        else if (this ==
            EntertainmentArtsAndRecreationSpecificSectors) onEntertainmentArtsAndRecreationSpecificSectors();
        else if (this == ExtraterritorialAndHouseholdActivities) onExtraterritorialAndHouseholdActivities();
        else if (this == FinancialServices) onFinancialServices();
        else if (this == FinancialServicesOthersAndInsurance) onFinancialServicesOthersAndInsurance();
        else if (this == FoodAndBeverageServices) onFoodAndBeverageServices();
        else if (this == Healthcare) onHealthcare();
        else if (this == HealthcareCounsellingAndSocialServices) onHealthcareCounsellingAndSocialServices();
        else if (this == InformationTechnologyAndMedia) onInformationTechnologyAndMedia();
        else if (this == InformationTechnologyAndMediaOnlineGaming) onInformationTechnologyAndMediaOnlineGaming();
        else if (this == InformationTechnologyAndMediaPrintPublishing) onInformationTechnologyAndMediaPrintPublishing();
        else if (this ==
            InformationTechnologyAndMediaTelecommunications) onInformationTechnologyAndMediaTelecommunications();
        else if (this == Manufacturing) onManufacturing();
        else if (this == ManufacturingPharmaceuticals) onManufacturingPharmaceuticals();
        else if (this == ManufacturingPreciousMetalsAndJewellery) onManufacturingPreciousMetalsAndJewellery();
        else if (this == ManufacturingWeaponsAndHazardous) onManufacturingWeaponsAndHazardous();
        else if (this == MiningAndQuarrying) onMiningAndQuarrying();
        else if (this == PersonalAndOtherServices) onPersonalAndOtherServices();
        else if (this == PersonalAndOtherServicesAdultAndWellness) onPersonalAndOtherServicesAdultAndWellness();
        else if (this ==
            PersonalAndOtherServicesNonprofitAndMembershipOrganisations) onPersonalAndOtherServicesNonprofitAndMembershipOrganisations();
        else if (this == ProfessionalAndTechnicalServices) onProfessionalAndTechnicalServices();
        else if (this ==
            ProfessionalAndTechnicalServicesLegalAndFiduciary) onProfessionalAndTechnicalServicesLegalAndFiduciary();
        else if (this == ProfessionalAndTechnicalServicesUnregulated) onProfessionalAndTechnicalServicesUnregulated();
        else if (this == PublicAdministration) onPublicAdministration();
        else if (this == PublicAdministrationJudicial) onPublicAdministrationJudicial();
        else if (this == RealEstate) onRealEstate();
        else if (this == RealEstateAgencyAndBrokerage) onRealEstateAgencyAndBrokerage();
        else if (this == RetailTrade) onRetailTrade();
        else if (this == RetailTradeSpeciality) onRetailTradeSpeciality();
        else if (this == RetailTradeSpecificSectors) onRetailTradeSpecificSectors();
        else if (this == TransportationAndLogistics) onTransportationAndLogistics();
        else if (this == TransportationAndLogisticsCruiseLines) onTransportationAndLogisticsCruiseLines();
        else if (this == TransportationAndLogisticsRailAndStorage) onTransportationAndLogisticsRailAndStorage();
        else if (this == UtilitiesAndEnergy) onUtilitiesAndEnergy();
        else if (this == WholesaleTrade) onWholesaleTrade();
        else if (this == WholesaleTradeIndustrial) onWholesaleTradeIndustrial();
        else if (this == WholesaleTradeLuxuryAndCollectibles) onWholesaleTradeLuxuryAndCollectibles();
        else if (this == WholesaleTradePetroleumAndChemicals) onWholesaleTradePetroleumAndChemicals();
        else otherwise(Value);
    }
}
