import { baseURL } from "./baseURL";
import { IProduct, IProductData, IProductIds } from "../model/product";

export const GET = async<T>(request: RequestInfo): Promise<T | undefined> => {
    return await fetch(request)
        .then(response => response.json())
        .catch(ex => new Error("Fetch fail!"));
};

export const POST = async<T>(request: RequestInfo, postData: object): Promise<T | undefined> => {
    return await fetch(request, {
        method: "POST",
        body: JSON.stringify(postData),
        headers: {"Content-Type": "application/json"}
    })
        .then(response => response.json())
        .catch(ex => new Error("Fetch fail!"));
};

export module TermekService {

    export const page = async (page: number): Promise<IProductData[]> => {
        const url: string = `${baseURL}termek?page=${page.toString()}`;
        const termek: IProduct | undefined = await GET<IProduct>(url);

        return termek ? termek.data : [];
    }

    export const byCikkszam = async (cikkszam: string): Promise<IProductData | undefined> => {
        const url: string = `${baseURL}termek/${cikkszam}`;
        const termekData: IProductData | undefined = await GET<IProductData>(url);
        return termekData;
    }

    export const getAll = async (): Promise<IProductData[]> => {
        const url: string = `${baseURL}termek`;
        const termekData: IProductData[] | undefined = await GET<IProductData[]>(url);
        return termekData ? termekData : [];
    }

    export const sendOrder = async (postData: any[]): Promise<any | undefined> => {
        const url: string = `${baseURL}rendeles`;
        let payload: object = {
            vasarlo_id: 7,
            rendelesi_tetelek: postData
        };
        return await POST(url, payload);
    }
}

