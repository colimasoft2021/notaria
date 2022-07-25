import React, { useState, useEffect } from "react";
import axios from "axios";
import Cookies from "universal-cookie";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Input from "../components/input/Input";
import FormActo from "../components/formActo/FormActo";
import TitleHeader from "../components/title/TitleHeader";
import styles from "../scss/pages/CatalogoActos.module.scss";
import Button from "../components/button/Button";
import editIcon from "../icons/editIcon.png";
import saveIcon from "../icons/saveIcon.png";
import deleteIcon from "../icons/deleteIcon.png";

export default function CatalogoActos() {
    const [actos, getActos] = useState([]);
    const state = useSelector((state) => state);
    let navigate = useNavigate();
    const cookies = new Cookies();
    const token = cookies.get("data");

    const showData = () => {

        const URL = "https://localhost:7028/api/Acto/GetActoPasos?id=1";
        const config = {
            headers: {
                Authorization: "Bearer " + token
            }
        }
        axios.get(URL, config)
            .then((response) => {
                getActos(response);
            }).catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        showData();
    }, []);

    console.log(actos);

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
                            <Button text="+ Agregar nuevo acto" variant="buttonAddActo" onClick={handleClick} />
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
                        <div className={styles.containerActos}>
                            <FormActo />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
