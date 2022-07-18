import React, { useState, useEffect } from "react";
import axios from "axios";
import Cookies from "universal-cookie";
import { useSelector } from "react-redux";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import excelIcon from "../icons/excelIcon.png";
import styles from "../scss/pages/Inicio.module.scss";

export default function Inicio() {
    const state = useSelector((state) => state);
    const [data, setData] = useState([]);
    const cookies = new Cookies();
    const token = cookies.get("data");
    //Obtener datos de usuario a modificar
    const getDataUser = () => {

        const URL = "https://localhost:7028/api/Acto/GetActoPasos";
        const config = {
            headers: {
                Authorization: "Bearer " + token
            }
        }
        axios.get(URL, config)
            .then((response) => {
                console.log(response)
            }).catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        getDataUser();
    }, []);

    console.log(data)
    return (
        <div className={styles.homeContainer}>
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
                </div>
                <div className={styles.titleContainer}>
                    <TitleHeader icon={excelIcon} text="Trámites" />
                </div>
                <div className={styles.filtersContainer}>
                    <div className={styles.filter}>
                        <Input
                            type="text"
                            placeholder="No. Escritura"
                            variant="filterInput"
                        />
                    </div>
                    <div className={styles.filter}>
                        <Input
                            type="text"
                            placeholder="Tipo de acto"
                            variant="filterInput"
                        />
                    </div>
                    <div className={styles.filter}>
                        <Input
                            type="text"
                            placeholder="Fecha inicio"
                            variant="filterInput"
                        />
                    </div>
                    <div className={styles.filter}>
                        <Input type="text" placeholder="Días" variant="filterInput" />
                    </div>
                    <div className={styles.filter}>
                        <Input type="text" placeholder="Estado" variant="filterInput" />
                    </div>
                </div>
                <div className={styles.tableContentContainer}>
                    <Table />
                </div>
            </div>
        </div>
    );
}
