import { IonCardContent, IonText } from "@ionic/react";
import React from "react";

interface IProps {
    label: string,
    termekek: number[];
}

const TermekDetailComponent: React.FC<IProps> = (props: IProps): JSX.Element => {

    const list: JSX.Element =
        <IonText>
            {
                props.termekek.map(termek => <li>{termek}</li>)
            }
        </IonText>
    const empty: JSX.Element =
        <IonText>
            No data available
        </IonText>

    return (
        <IonCardContent>
            <IonText>
                <p className="right">{props.label}</p>
            </IonText>
            {
                props.termekek.length == 0 ? empty : list
            }
            <hr />
        </IonCardContent>
    );
}

export default TermekDetailComponent;