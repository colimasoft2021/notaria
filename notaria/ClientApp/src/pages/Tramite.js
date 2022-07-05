import React from "react";
import { useSelector } from "react-redux";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import FormSearch from "../components/formSearch/FormSearch";
import excelIcon from "../icons/excelIcon.png";
import styles from "../scss/pages/Tramite.module.scss";

export default function Tramite() {
    const state = useSelector((state) => state);

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
                    <div className={styles.formSearchContainer}>
                        <FormSearch />
                    </div>
                    <div className={styles.titleContainer}>
                        <TitleHeader text="COMPRA-VENTA" banner icon={excelIcon} />
                    </div>
                    <div className={styles.tableContentContainer}>
                        <Table />
                    </div>
                </div>
            </div>
        </div>
    );
}
