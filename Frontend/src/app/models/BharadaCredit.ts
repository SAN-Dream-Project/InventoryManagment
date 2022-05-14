export interface BharadaCredit {
    id: any,
    retailerName:any,
    totalAmount:any
    paidAmount:any
    createdBy: string,
    createdDate: string,
    modifiedBy: string,
    modifiedDate: string
  }

export interface BharadaCreditInput {
    id: any,
    retailerID:any,
    BharadaSaleDetailID:any
    paidAmount:any
    createdBy: string,
    createdDate: string,
    modifiedBy: string,
    modifiedDate: string
  }