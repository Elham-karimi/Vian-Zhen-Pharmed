export interface Product{
    name : string,
    shortDescription : string,
    SpecificSpecification :{
        productType : string,
        consumerGroup : string,
        usageCases : string,
        dosage : string,
        combination : string
    }
}