using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The industry the user is professionally active in.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<UserIndustry>))]
public sealed record UserIndustry : OpenStringEnum<UserIndustry>
{
    private UserIndustry(string value) : base(value)
    {
    }

    public static readonly UserIndustry AgricultureForestryAndFishing = new("AGRICULTURE_FORESTRY_AND_FISHING");

    public static readonly UserIndustry Manufacturing = new("MANUFACTURING");

    public static readonly UserIndustry UtilitiesAndEnergy = new("UTILITIES_AND_ENERGY");

    public static readonly UserIndustry WholesaleTrade = new("WHOLESALE_TRADE");

    public static readonly UserIndustry RetailTrade = new("RETAIL_TRADE");

    public static readonly UserIndustry TransportationAndLogisticsRailAndStorage = new(
        "TRANSPORTATION_AND_LOGISTICS_RAIL_AND_STORAGE");

    public static readonly UserIndustry InformationTechnologyAndMediaPrintPublishing = new(
        "INFORMATION_TECHNOLOGY_AND_MEDIA_PRINT_PUBLISHING");

    public static readonly UserIndustry AdminAndSupportServicesCleaningAndFacilities = new(
        "ADMIN_AND_SUPPORT_SERVICES_CLEANING_AND_FACILITIES");

    public static readonly UserIndustry EducationHigherEducation = new("EDUCATION_HIGHER_EDUCATION");

    public static readonly UserIndustry EntertainmentArtsAndRecreationNatureAndZoos = new(
        "ENTERTAINMENT_ARTS_AND_RECREATION_NATURE_AND_ZOOS");

    public static readonly UserIndustry ExtraterritorialAndHouseholdActivities = new(
        "EXTRATERRITORIAL_AND_HOUSEHOLD_ACTIVITIES");

    public static readonly UserIndustry ManufacturingPharmaceuticals = new("MANUFACTURING_PHARMACEUTICALS");

    public static readonly UserIndustry Construction = new("CONSTRUCTION");

    public static readonly UserIndustry RetailTradeSpeciality = new("RETAIL_TRADE_SPECIALITY");

    public static readonly UserIndustry WholesaleTradeIndustrial = new("WHOLESALE_TRADE_INDUSTRIAL");

    public static readonly UserIndustry TransportationAndLogistics = new("TRANSPORTATION_AND_LOGISTICS");

    public static readonly UserIndustry AccommodationAndHospitality = new("ACCOMMODATION_AND_HOSPITALITY");

    public static readonly UserIndustry InformationTechnologyAndMedia = new("INFORMATION_TECHNOLOGY_AND_MEDIA");

    public static readonly UserIndustry RealEstate = new("REAL_ESTATE");

    public static readonly UserIndustry ProfessionalAndTechnicalServices = new("PROFESSIONAL_AND_TECHNICAL_SERVICES");

    public static readonly UserIndustry AdminAndSupportServices = new("ADMIN_AND_SUPPORT_SERVICES");

    public static readonly UserIndustry PublicAdministration = new("PUBLIC_ADMINISTRATION");

    public static readonly UserIndustry Education = new("EDUCATION");

    public static readonly UserIndustry Healthcare = new("HEALTHCARE");

    public static readonly UserIndustry EntertainmentArtsAndRecreation = new("ENTERTAINMENT_ARTS_AND_RECREATION");

    public static readonly UserIndustry PersonalAndOtherServices = new("PERSONAL_AND_OTHER_SERVICES");

    public static readonly UserIndustry MiningAndQuarrying = new("MINING_AND_QUARRYING");

    public static readonly UserIndustry ManufacturingWeaponsAndHazardous = new("MANUFACTURING_WEAPONS_AND_HAZARDOUS");

    public static readonly UserIndustry ManufacturingPreciousMetalsAndJewellery = new(
        "MANUFACTURING_PRECIOUS_METALS_AND_JEWELLERY");

    public static readonly UserIndustry RetailTradeSpecificSectors = new("RETAIL_TRADE_SPECIFIC_SECTORS");

    public static readonly UserIndustry WholesaleTradePetroleumAndChemicals = new(
        "WHOLESALE_TRADE_PETROLEUM_AND_CHEMICALS");

    public static readonly UserIndustry WholesaleTradeLuxuryAndCollectibles = new(
        "WHOLESALE_TRADE_LUXURY_AND_COLLECTIBLES");

    public static readonly UserIndustry InformationTechnologyAndMediaTelecommunications = new(
        "INFORMATION_TECHNOLOGY_AND_MEDIA_TELECOMMUNICATIONS");

    public static readonly UserIndustry TransportationAndLogisticsCruiseLines = new(
        "TRANSPORTATION_AND_LOGISTICS_CRUISE_LINES");

    public static readonly UserIndustry AccommodationAndHospitalityTimesharing = new(
        "ACCOMMODATION_AND_HOSPITALITY_TIMESHARING");

    public static readonly UserIndustry FoodAndBeverageServices = new("FOOD_AND_BEVERAGE_SERVICES");

    public static readonly UserIndustry InformationTechnologyAndMediaOnlineGaming = new(
        "INFORMATION_TECHNOLOGY_AND_MEDIA_ONLINE_GAMING");

    public static readonly UserIndustry FinancialServices = new("FINANCIAL_SERVICES");

    public static readonly UserIndustry RealEstateAgencyAndBrokerage = new("REAL_ESTATE_AGENCY_AND_BROKERAGE");

    public static readonly UserIndustry ProfessionalAndTechnicalServicesLegalAndFiduciary = new(
        "PROFESSIONAL_AND_TECHNICAL_SERVICES_LEGAL_AND_FIDUCIARY");

    public static readonly UserIndustry ProfessionalAndTechnicalServicesUnregulated = new(
        "PROFESSIONAL_AND_TECHNICAL_SERVICES_UNREGULATED");

    public static readonly UserIndustry AdminAndSupportServicesSpecificSectors = new(
        "ADMIN_AND_SUPPORT_SERVICES_SPECIFIC_SECTORS");

    public static readonly UserIndustry AdminAndSupportServicesSecurityAndInvestigation = new(
        "ADMIN_AND_SUPPORT_SERVICES_SECURITY_AND_INVESTIGATION");

    public static readonly UserIndustry PublicAdministrationJudicial = new("PUBLIC_ADMINISTRATION_JUDICIAL");

    public static readonly UserIndustry HealthcareCounsellingAndSocialServices = new(
        "HEALTHCARE_COUNSELLING_AND_SOCIAL_SERVICES");

    public static readonly UserIndustry EntertainmentArtsAndRecreationSpecificSectors = new(
        "ENTERTAINMENT_ARTS_AND_RECREATION_SPECIFIC_SECTORS");

    public static readonly UserIndustry PersonalAndOtherServicesNonprofitAndMembershipOrganisations = new(
        "PERSONAL_AND_OTHER_SERVICES_NONPROFIT_AND_MEMBERSHIP_ORGANISATIONS");

    public static readonly UserIndustry PersonalAndOtherServicesAdultAndWellness = new(
        "PERSONAL_AND_OTHER_SERVICES_ADULT_AND_WELLNESS");

    public static readonly UserIndustry Other = new("OTHER");

    public TResult Match<TResult>(Func<TResult> onAgricultureForestryAndFishing,
        Func<TResult> onManufacturing,
        Func<TResult> onUtilitiesAndEnergy,
        Func<TResult> onWholesaleTrade,
        Func<TResult> onRetailTrade,
        Func<TResult> onTransportationAndLogisticsRailAndStorage,
        Func<TResult> onInformationTechnologyAndMediaPrintPublishing,
        Func<TResult> onAdminAndSupportServicesCleaningAndFacilities,
        Func<TResult> onEducationHigherEducation,
        Func<TResult> onEntertainmentArtsAndRecreationNatureAndZoos,
        Func<TResult> onExtraterritorialAndHouseholdActivities,
        Func<TResult> onManufacturingPharmaceuticals,
        Func<TResult> onConstruction,
        Func<TResult> onRetailTradeSpeciality,
        Func<TResult> onWholesaleTradeIndustrial,
        Func<TResult> onTransportationAndLogistics,
        Func<TResult> onAccommodationAndHospitality,
        Func<TResult> onInformationTechnologyAndMedia,
        Func<TResult> onRealEstate,
        Func<TResult> onProfessionalAndTechnicalServices,
        Func<TResult> onAdminAndSupportServices,
        Func<TResult> onPublicAdministration,
        Func<TResult> onEducation,
        Func<TResult> onHealthcare,
        Func<TResult> onEntertainmentArtsAndRecreation,
        Func<TResult> onPersonalAndOtherServices,
        Func<TResult> onMiningAndQuarrying,
        Func<TResult> onManufacturingWeaponsAndHazardous,
        Func<TResult> onManufacturingPreciousMetalsAndJewellery,
        Func<TResult> onRetailTradeSpecificSectors,
        Func<TResult> onWholesaleTradePetroleumAndChemicals,
        Func<TResult> onWholesaleTradeLuxuryAndCollectibles,
        Func<TResult> onInformationTechnologyAndMediaTelecommunications,
        Func<TResult> onTransportationAndLogisticsCruiseLines,
        Func<TResult> onAccommodationAndHospitalityTimesharing,
        Func<TResult> onFoodAndBeverageServices,
        Func<TResult> onInformationTechnologyAndMediaOnlineGaming,
        Func<TResult> onFinancialServices,
        Func<TResult> onRealEstateAgencyAndBrokerage,
        Func<TResult> onProfessionalAndTechnicalServicesLegalAndFiduciary,
        Func<TResult> onProfessionalAndTechnicalServicesUnregulated,
        Func<TResult> onAdminAndSupportServicesSpecificSectors,
        Func<TResult> onAdminAndSupportServicesSecurityAndInvestigation,
        Func<TResult> onPublicAdministrationJudicial,
        Func<TResult> onHealthcareCounsellingAndSocialServices,
        Func<TResult> onEntertainmentArtsAndRecreationSpecificSectors,
        Func<TResult> onPersonalAndOtherServicesNonprofitAndMembershipOrganisations,
        Func<TResult> onPersonalAndOtherServicesAdultAndWellness,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AgricultureForestryAndFishing => onAgricultureForestryAndFishing(),
            _ when this == Manufacturing => onManufacturing(),
            _ when this == UtilitiesAndEnergy => onUtilitiesAndEnergy(),
            _ when this == WholesaleTrade => onWholesaleTrade(),
            _ when this == RetailTrade => onRetailTrade(),
            _ when this == TransportationAndLogisticsRailAndStorage => onTransportationAndLogisticsRailAndStorage(),
            _ when this ==
                InformationTechnologyAndMediaPrintPublishing => onInformationTechnologyAndMediaPrintPublishing(),
            _ when this ==
                AdminAndSupportServicesCleaningAndFacilities => onAdminAndSupportServicesCleaningAndFacilities(),
            _ when this == EducationHigherEducation => onEducationHigherEducation(),
            _ when this ==
                EntertainmentArtsAndRecreationNatureAndZoos => onEntertainmentArtsAndRecreationNatureAndZoos(),
            _ when this == ExtraterritorialAndHouseholdActivities => onExtraterritorialAndHouseholdActivities(),
            _ when this == ManufacturingPharmaceuticals => onManufacturingPharmaceuticals(),
            _ when this == Construction => onConstruction(),
            _ when this == RetailTradeSpeciality => onRetailTradeSpeciality(),
            _ when this == WholesaleTradeIndustrial => onWholesaleTradeIndustrial(),
            _ when this == TransportationAndLogistics => onTransportationAndLogistics(),
            _ when this == AccommodationAndHospitality => onAccommodationAndHospitality(),
            _ when this == InformationTechnologyAndMedia => onInformationTechnologyAndMedia(),
            _ when this == RealEstate => onRealEstate(),
            _ when this == ProfessionalAndTechnicalServices => onProfessionalAndTechnicalServices(),
            _ when this == AdminAndSupportServices => onAdminAndSupportServices(),
            _ when this == PublicAdministration => onPublicAdministration(),
            _ when this == Education => onEducation(),
            _ when this == Healthcare => onHealthcare(),
            _ when this == EntertainmentArtsAndRecreation => onEntertainmentArtsAndRecreation(),
            _ when this == PersonalAndOtherServices => onPersonalAndOtherServices(),
            _ when this == MiningAndQuarrying => onMiningAndQuarrying(),
            _ when this == ManufacturingWeaponsAndHazardous => onManufacturingWeaponsAndHazardous(),
            _ when this == ManufacturingPreciousMetalsAndJewellery => onManufacturingPreciousMetalsAndJewellery(),
            _ when this == RetailTradeSpecificSectors => onRetailTradeSpecificSectors(),
            _ when this == WholesaleTradePetroleumAndChemicals => onWholesaleTradePetroleumAndChemicals(),
            _ when this == WholesaleTradeLuxuryAndCollectibles => onWholesaleTradeLuxuryAndCollectibles(),
            _ when this ==
                InformationTechnologyAndMediaTelecommunications => onInformationTechnologyAndMediaTelecommunications(),
            _ when this == TransportationAndLogisticsCruiseLines => onTransportationAndLogisticsCruiseLines(),
            _ when this == AccommodationAndHospitalityTimesharing => onAccommodationAndHospitalityTimesharing(),
            _ when this == FoodAndBeverageServices => onFoodAndBeverageServices(),
            _ when this == InformationTechnologyAndMediaOnlineGaming => onInformationTechnologyAndMediaOnlineGaming(),
            _ when this == FinancialServices => onFinancialServices(),
            _ when this == RealEstateAgencyAndBrokerage => onRealEstateAgencyAndBrokerage(),
            _ when this ==
                ProfessionalAndTechnicalServicesLegalAndFiduciary => onProfessionalAndTechnicalServicesLegalAndFiduciary(),
            _ when this ==
                ProfessionalAndTechnicalServicesUnregulated => onProfessionalAndTechnicalServicesUnregulated(),
            _ when this == AdminAndSupportServicesSpecificSectors => onAdminAndSupportServicesSpecificSectors(),
            _ when this ==
                AdminAndSupportServicesSecurityAndInvestigation => onAdminAndSupportServicesSecurityAndInvestigation(),
            _ when this == PublicAdministrationJudicial => onPublicAdministrationJudicial(),
            _ when this == HealthcareCounsellingAndSocialServices => onHealthcareCounsellingAndSocialServices(),
            _ when this ==
                EntertainmentArtsAndRecreationSpecificSectors => onEntertainmentArtsAndRecreationSpecificSectors(),
            _ when this ==
                PersonalAndOtherServicesNonprofitAndMembershipOrganisations => onPersonalAndOtherServicesNonprofitAndMembershipOrganisations(),
            _ when this == PersonalAndOtherServicesAdultAndWellness => onPersonalAndOtherServicesAdultAndWellness(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onAgricultureForestryAndFishing,
        Action onManufacturing,
        Action onUtilitiesAndEnergy,
        Action onWholesaleTrade,
        Action onRetailTrade,
        Action onTransportationAndLogisticsRailAndStorage,
        Action onInformationTechnologyAndMediaPrintPublishing,
        Action onAdminAndSupportServicesCleaningAndFacilities,
        Action onEducationHigherEducation,
        Action onEntertainmentArtsAndRecreationNatureAndZoos,
        Action onExtraterritorialAndHouseholdActivities,
        Action onManufacturingPharmaceuticals,
        Action onConstruction,
        Action onRetailTradeSpeciality,
        Action onWholesaleTradeIndustrial,
        Action onTransportationAndLogistics,
        Action onAccommodationAndHospitality,
        Action onInformationTechnologyAndMedia,
        Action onRealEstate,
        Action onProfessionalAndTechnicalServices,
        Action onAdminAndSupportServices,
        Action onPublicAdministration,
        Action onEducation,
        Action onHealthcare,
        Action onEntertainmentArtsAndRecreation,
        Action onPersonalAndOtherServices,
        Action onMiningAndQuarrying,
        Action onManufacturingWeaponsAndHazardous,
        Action onManufacturingPreciousMetalsAndJewellery,
        Action onRetailTradeSpecificSectors,
        Action onWholesaleTradePetroleumAndChemicals,
        Action onWholesaleTradeLuxuryAndCollectibles,
        Action onInformationTechnologyAndMediaTelecommunications,
        Action onTransportationAndLogisticsCruiseLines,
        Action onAccommodationAndHospitalityTimesharing,
        Action onFoodAndBeverageServices,
        Action onInformationTechnologyAndMediaOnlineGaming,
        Action onFinancialServices,
        Action onRealEstateAgencyAndBrokerage,
        Action onProfessionalAndTechnicalServicesLegalAndFiduciary,
        Action onProfessionalAndTechnicalServicesUnregulated,
        Action onAdminAndSupportServicesSpecificSectors,
        Action onAdminAndSupportServicesSecurityAndInvestigation,
        Action onPublicAdministrationJudicial,
        Action onHealthcareCounsellingAndSocialServices,
        Action onEntertainmentArtsAndRecreationSpecificSectors,
        Action onPersonalAndOtherServicesNonprofitAndMembershipOrganisations,
        Action onPersonalAndOtherServicesAdultAndWellness,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == AgricultureForestryAndFishing) onAgricultureForestryAndFishing();
        else if (this == Manufacturing) onManufacturing();
        else if (this == UtilitiesAndEnergy) onUtilitiesAndEnergy();
        else if (this == WholesaleTrade) onWholesaleTrade();
        else if (this == RetailTrade) onRetailTrade();
        else if (this == TransportationAndLogisticsRailAndStorage) onTransportationAndLogisticsRailAndStorage();
        else if (this == InformationTechnologyAndMediaPrintPublishing) onInformationTechnologyAndMediaPrintPublishing();
        else if (this == AdminAndSupportServicesCleaningAndFacilities) onAdminAndSupportServicesCleaningAndFacilities();
        else if (this == EducationHigherEducation) onEducationHigherEducation();
        else if (this == EntertainmentArtsAndRecreationNatureAndZoos) onEntertainmentArtsAndRecreationNatureAndZoos();
        else if (this == ExtraterritorialAndHouseholdActivities) onExtraterritorialAndHouseholdActivities();
        else if (this == ManufacturingPharmaceuticals) onManufacturingPharmaceuticals();
        else if (this == Construction) onConstruction();
        else if (this == RetailTradeSpeciality) onRetailTradeSpeciality();
        else if (this == WholesaleTradeIndustrial) onWholesaleTradeIndustrial();
        else if (this == TransportationAndLogistics) onTransportationAndLogistics();
        else if (this == AccommodationAndHospitality) onAccommodationAndHospitality();
        else if (this == InformationTechnologyAndMedia) onInformationTechnologyAndMedia();
        else if (this == RealEstate) onRealEstate();
        else if (this == ProfessionalAndTechnicalServices) onProfessionalAndTechnicalServices();
        else if (this == AdminAndSupportServices) onAdminAndSupportServices();
        else if (this == PublicAdministration) onPublicAdministration();
        else if (this == Education) onEducation();
        else if (this == Healthcare) onHealthcare();
        else if (this == EntertainmentArtsAndRecreation) onEntertainmentArtsAndRecreation();
        else if (this == PersonalAndOtherServices) onPersonalAndOtherServices();
        else if (this == MiningAndQuarrying) onMiningAndQuarrying();
        else if (this == ManufacturingWeaponsAndHazardous) onManufacturingWeaponsAndHazardous();
        else if (this == ManufacturingPreciousMetalsAndJewellery) onManufacturingPreciousMetalsAndJewellery();
        else if (this == RetailTradeSpecificSectors) onRetailTradeSpecificSectors();
        else if (this == WholesaleTradePetroleumAndChemicals) onWholesaleTradePetroleumAndChemicals();
        else if (this == WholesaleTradeLuxuryAndCollectibles) onWholesaleTradeLuxuryAndCollectibles();
        else if (this ==
            InformationTechnologyAndMediaTelecommunications) onInformationTechnologyAndMediaTelecommunications();
        else if (this == TransportationAndLogisticsCruiseLines) onTransportationAndLogisticsCruiseLines();
        else if (this == AccommodationAndHospitalityTimesharing) onAccommodationAndHospitalityTimesharing();
        else if (this == FoodAndBeverageServices) onFoodAndBeverageServices();
        else if (this == InformationTechnologyAndMediaOnlineGaming) onInformationTechnologyAndMediaOnlineGaming();
        else if (this == FinancialServices) onFinancialServices();
        else if (this == RealEstateAgencyAndBrokerage) onRealEstateAgencyAndBrokerage();
        else if (this ==
            ProfessionalAndTechnicalServicesLegalAndFiduciary) onProfessionalAndTechnicalServicesLegalAndFiduciary();
        else if (this == ProfessionalAndTechnicalServicesUnregulated) onProfessionalAndTechnicalServicesUnregulated();
        else if (this == AdminAndSupportServicesSpecificSectors) onAdminAndSupportServicesSpecificSectors();
        else if (this ==
            AdminAndSupportServicesSecurityAndInvestigation) onAdminAndSupportServicesSecurityAndInvestigation();
        else if (this == PublicAdministrationJudicial) onPublicAdministrationJudicial();
        else if (this == HealthcareCounsellingAndSocialServices) onHealthcareCounsellingAndSocialServices();
        else if (this ==
            EntertainmentArtsAndRecreationSpecificSectors) onEntertainmentArtsAndRecreationSpecificSectors();
        else if (this ==
            PersonalAndOtherServicesNonprofitAndMembershipOrganisations) onPersonalAndOtherServicesNonprofitAndMembershipOrganisations();
        else if (this == PersonalAndOtherServicesAdultAndWellness) onPersonalAndOtherServicesAdultAndWellness();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
