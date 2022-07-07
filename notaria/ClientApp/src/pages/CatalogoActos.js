import React from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import styles from "../scss/pages/CatalogoActos.module.scss";
import Button from "../components/button/Button";
import editIcon from "../icons/editIcon.png";
import saveIcon from "../icons/saveIcon.png";
import deleteIcon from "../icons/deleteIcon.png";

export default function CatalogoActos() {
    const state = useSelector((state) => state);
    let navigate = useNavigate();

    const handleClick = () => {
        navigate("/configuracion");
    };

    return (
        <div className={styles.tramiteContainer}>
            <div
                className={
                    state.stateMenu
                        ? styles.sideBarContainer
                        : `${styles.sideBarContainer} ${styles.sideBarClose}`
                }
            >
                <SideBar />
            </div>
            <div
                className={
                    state.stateMenu
                        ? styles.contentContainer
                        : `${styles.contentContainer} ${styles.contentContainerClose}`
                }
            >
                <div
                    className={
                        state.stateMenu
                            ? styles.topBarContentContainer
                            : `${styles.topBarContentContainer} ${styles.topBarContentContainerClose}`
                    }
                >
                    <div className={styles.topBarContainer}>
                        <TopBar />
                    </div>
                    <div className={styles.titleContainer}>
                        <TitleHeader text="Catálogo de actos" withoutIcon />
                    </div>
                    <div className={styles.formContainer}>
                        <div className={styles.buttonContainer}>
                            <Button text="+ Agregar nuevo acto" variant="buttonAddActo" />
                            <div className={styles.buttonIconContainer}>
                                <div>
                                    <Button icon={editIcon} variantIcon="backgroundBlue" />
                                </div>
                                <div>
                                    <Button icon={saveIcon} variantIcon="backgroundBlue" />
                                </div>
                                <div>
                                    <Button icon={deleteIcon} variantIcon="backgroundBlue" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
