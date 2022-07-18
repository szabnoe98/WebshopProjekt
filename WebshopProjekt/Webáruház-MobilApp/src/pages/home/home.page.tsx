import "./home.style.css";

import React, { useEffect, useState } from "react";
import {
    IonPage,
    IonHeader,
    IonTitle,
    IonToolbar,
    IonContent,
    IonList,
    IonListHeader,
    IonInfiniteScroll,
    IonInfiniteScrollContent,
    IonButton
}
    from "@ionic/react";
import { IProductData } from "../../model/product";
import { TermekService } from "../../service/http";
import TermekComponent from "../../components/termek.component";
import { termekdetail } from "../../model/data";

const HomePage: React.FC = (): JSX.Element => {
    const [termekek, setTermekek] = useState<IProductData[]>([]);
    const [disableInfiniteScroll, setDisableInfiniteScroll] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [selectedItems, setSelectedItems] = useState<object[]>([]);


    useEffect(() => {
        fetchData();
        setIsLoading(false);
    }, []);

    const fetchData = async (): Promise<void> => {
        const data: IProductData[] = await TermekService.getAll();
        if (data && data.length > 0) {
            setTermekek([...termekek, ...data]);
            setDisableInfiniteScroll(false);
           
        }
        else {
            setDisableInfiniteScroll(false);
        }
    }

    const selectItem = (item: number) => {        
            selectedItems.push({cikkszam: item, mennyiseg: 1});
            setSelectedItems(selectedItems);            
    }


    return (
        <IonPage >
            <IonHeader>
                <IonToolbar>
                    <IonTitle className='cntent'>Termékeink listája</IonTitle>
                </IonToolbar>
            </IonHeader>
            <IonContent >
                <IonList className="bgs">
                    <IonListHeader className="listname">Válassza ki mely termékeinkről szeretne értesítést kapni!</IonListHeader>
                    <div className="listaelemek">
                    {
                        termekek.map((data: IProductData, i: number) => i < 10 && <TermekComponent termek={data} foto={termekdetail[i].sourceUrl} key={i} onChange={selectItem} />)
                    }
                    </div>
                </IonList>
                { selectedItems &&
                <IonButton className="floatingButton" onClick={() => {
                         TermekService.sendOrder(selectedItems).then(data => alert("Kérését sikeresen rögzítettük!: " + data)
                         ).catch(err => 
                                alert("Valami baj van! hiba: " + err)
                         );
                }}>
                    Küldés
                </IonButton>
                }
            </IonContent>
        </IonPage>
    );
}

export default HomePage;