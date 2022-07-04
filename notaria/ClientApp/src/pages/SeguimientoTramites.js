import React from "react";
import { useSelector } from "react-redux";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import magnifyingGlassIcon from "../icons/magnifyingGlassIcon.png";
import styles from "../scss/pages/SeguimientoTramites.module.scss";

export default function SeguimientoTramites() {
    const state = useSelector((state) => state);

    return (
        <div className={styles.seguimientoTramitesContainer}>
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
                    <TitleHeader text="Seguimiento de trámites" withoutIcon />
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
