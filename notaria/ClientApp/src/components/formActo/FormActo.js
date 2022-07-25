import Button from "../../components/button/Button";
import styles from "./FormActo.module.scss";
import arrowBlack from "../../icons/arrowBlack4x.png";

export default function FormActo() {
    return (
        <div className={styles.mainContainer}>
            <div className={styles.buttonContainer}>
                <Button icon={arrowBlack} text="2so Aviso" variantIcon="arrowBlack4x" variant="buttonDropDown" />
            </div>
        </div>   
    );
}