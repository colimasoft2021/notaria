import React from "react";
import styles from "./FormSearch.module.scss";
import Input from "../input/Input";
import Button from "../../components/button/Button";
import paperClipIcon from "../../icons/paperClipIcon.png";

export default function FormSearch() {
    return (
        <div className={styles.formContainer}>
            <form>
                <div className={styles.formHeader}>
                    <p className={styles.columOne}>Número de escritura</p>
                    <p className={styles.columTwo}>Tipo de acto</p>
                    <p className={styles.columThree}>Fecha escritura</p>
                    <p className={styles.columFour}>Fecha firma</p>
                </div>
                <div className={styles.inputsContainer}>
                    <div className={styles.rowOneContainer}>
                        <div className={styles.rowOneInputOne}>
                            <Input type="text" variant="noEscritura" />
                        </div>
                        <div className={styles.rowOneInputTwo}>
                            <Input type="text" variant="tipoActo" />
                        </div>
                        <div className={styles.rowOneInputThree}>
                            <Input type="date" variant="campoFecha" />
                        </div>
                        <div className={styles.rowOneInputFour}>
                            <Input type="date" variant="campoFecha" />
                        </div>
                    </div>
                    <div className={styles.rowTwoContainer}>
                        <div className={styles.rowTwoInputOne}>
                            <Input type="text" variant="partInput" />
                        </div>
                        <div className={styles.rowTwoInputTwo}>
                            <Input type="text" variant="partInput" />
                        </div>
                        <div className={styles.rowTwoInputThree}>
                            <Input
                                type="text"
                                variant="diasHabiles"
                                label="Días hábiles"
                                inputOverLabel
                            />
                        </div>
                        <div className={styles.rowTwoInputFour}>
                            <Input
                                type="text"
                                variant="responsable"
                                label="Responsable"
                                inputOverLabel
                            />
                        </div>
                    </div>
                </div>
                <div className={styles.buttonsContainer}>
                    <div className={styles.botonBuscarContainer}>
                        <Button text="Buscar" variant="buttonSearch" />
                    </div>
                    <div className={styles.botonSubirContainer}>
                        <Button
                            text="Subir un archivo adjunto"
                            variant="buttonUpload"
                            icon={paperClipIcon}
                            iconRight
                        />
                    </div>
                </div>
            </form>
        </div>
    );
}
