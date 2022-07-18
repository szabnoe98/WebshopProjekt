import { IonButton, IonCard, IonCardTitle, IonContent, IonGrid, IonHeader, IonItem, IonPage, IonTitle, IonToolbar } from "@ionic/react";
import "./kezdolap.style.css"

const KezdolapPage: React.FC = () => (

<IonPage>
    <IonContent fullscreen >
        <IonCard className="background">
            
            <div >
               
                <IonCard className="belepes">
                    <IonTitle className='content'>Üdvözöljük az <br/>Akció-Figyelő <br/> rendszerünkben!</IonTitle>
                </IonCard>
                <IonButton size="large" shape="round" class="nextbutton" routerLink="/home" >
                    Továbblépés a készlethez
                </IonButton>
            </div>
            
        </IonCard>
    </IonContent>
</IonPage>
)
export default KezdolapPage;