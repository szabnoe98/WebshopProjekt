import { IonAvatar, IonItem, IonLabel, IonCheckbox } from "@ionic/react";
import React from "react";
import { IProductData } from "./../model/product";

interface IProps {
    termek: IProductData;
    foto: string;
    onChange: (id: number) => void
}

const TermekComponent: React.FC<IProps> = (props: IProps): JSX.Element => {

    return (
        <><IonCheckbox className="checkbox" key={props.termek.cikkszam} checked={false} onIonChange={() => {
            props.onChange(props.termek.cikkszam);
        }}></IonCheckbox>
        <IonItem className="listcontent" routerLink={`/termek/${props.termek.cikkszam}`}>
            <IonAvatar slot="start">
                <img src={props.foto} alt={props.termek.cikknev} />
            </IonAvatar>
            <IonLabel>
                <h2>{props.termek.cikknev}</h2>
            </IonLabel>
        </IonItem></>
    );
}

export default TermekComponent;