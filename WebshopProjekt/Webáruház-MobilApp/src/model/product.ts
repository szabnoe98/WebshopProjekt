export interface IProduct {
    count: number;
    totalPages : number,
    nextPage: string;
    data: IProductData [];
}

export interface IProductData {
    cikkszam: number,
    cikknev: string,
    alkategoriakod: number,
    keszletDB: number,
    beszerzesi_ar: number,
    kiszereles: string,
    beszerzes_datuma: Date,
    foto: string,
    akcios_e: false 
}

export interface IProductIds {
    item: object
}

export interface IProductDetail {
    cikkszam: number;
    sourceUrl: string;
    description: string;
}