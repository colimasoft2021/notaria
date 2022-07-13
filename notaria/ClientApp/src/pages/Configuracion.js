import React, { useState, useEffect } from "react";
import axios from "axios";
import { useSelector } from "react-redux";
import Cookies from "universal-cookie";
import { useParams } from 'react-router-dom';
import TitleHeader from "../components/title/TitleHeader";
import TopBar from "../components/topbar/TopBar";
import SideBar from "../components/sidebar/SideBar";
import FormUser from "../components/formUser/FormUser";
import styles from "../scss/pages/Configuracion.module.scss";

export default function Configuracion() {
    const { id } = useParams();
    const cookies = new Cookies();
    const token = cookies.get("data");
    const [modifyUser, setModifyUser] = useState([]);

    //Obtener datos de usuario a modificar
    const getDataUser = () => {

        const URL = "https://localhost:7028/api/Usuario";
        const config = {
            headers: {
                Authorization: "Bearer " + token
            }
        }
        axios.get(URL, config)
            .then((response) => {
                response.data.map(user => {
                    if (id === user.id.toString()) {
                        setModifyUser(user);
                    }
                })
            }).catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
            getDataUser();
    }, []);

    const state = useSelector((state) => state);

    return (
        <div className={styles.configuracionContainer}>
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
                        <TitleHeader text="Usuario" withoutIcon />
                    </div>
                    <div className={styles.formContainer}>
                        <FormUser modifyUser={modifyUser} formType={id} />
                    </div>
                </div>
            </div>
        </div>
    );
}
