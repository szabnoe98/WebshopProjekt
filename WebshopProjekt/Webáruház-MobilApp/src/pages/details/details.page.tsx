import "./details.style.css"

import { RouteComponentProps, withRouter } from "react-router-dom";
import React from "react";
import { useEffect, useState } from "react";
import { IonCard, IonHeader, IonCardTitle, IonText, IonCardSubtitle, IonPage, IonToolbar, IonTitle, IonContent, IonCardHeader } from "@ionic/react";
import { IProductData, IProductDetail } from "./../../model/product";
import { termekdetail } from "./../../model/data";
import { TermekService } from "./../../service/http";
//import LoaderComponent from "../../components/Loader";
import TermekDetailComponent from "../../components/termek.reszletek.component";

interface IProps extends RouteComponentProps<{ cikkszam: string }> {
}

const DetailPage: React.FC<IProps> = (props: IProps): JSX.Element => {
    const [termek, setTermek] = useState<IProductData>();
    const [description, setDescription] = useState<string>();
    const [photo, setPhoto] = useState<string>();
    const [isLoading, setIsLoading] = useState<boolean>(true);

    useEffect(() => {
        fetchData();
    }, [props.match.params.cikkszam]);

    const fetchData = async (): Promise<void> => {
        const data: IProductData | undefined = await TermekService.byCikkszam(props.match.params.cikkszam);
        setTermek(data);
        let cikkszam = data?.cikkszam;
        if(cikkszam){
            let termekdetailSor = termekdetail.find((item: IProductDetail) => item.cikkszam === cikkszam);
                setDescription(termekdetailSor?.description);
                setPhoto(termekdetailSor?.sourceUrl);
        }
        setTimeout(() => {
            setIsLoading(false);
        }, 1000);
    }

    

    const card: JSX.Element =
        <IonCard className="kartya">
            <img src={photo} alt={termek?.cikknev} className="foto"/>
            <IonCardHeader>
                <IonCardTitle className="middle">
                    <IonText className="test">{termek?.cikknev}</IonText>
                </IonCardTitle>
                <IonCardSubtitle className="leiras">Termékleírás:</IonCardSubtitle>
                <IonText className="reszlet">
                    <br/>{description}
                </IonText>
                 <TermekDetailComponent label="Ár (Ft)" termekek={[termek?.beszerzesi_ar!]}></TermekDetailComponent>
                {/* <TermekDetailComponent label="Kiszerelés" termekek={[termek?.kiszereles!]}></TermekDetailComponent> */}
            </IonCardHeader>
        </IonCard>

    return (
        <IonPage>
            <IonHeader>
                
            </IonHeader>
            <IonContent fullscreen>
                {termek && card}
            </IonContent>
        </IonPage>

    );
}

export default withRouter(DetailPage);