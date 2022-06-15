import React, { useState } from "react";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import excelIcon from "../icons/excelIcon.png";
import styles from "../scss/pages/Inicio.module.scss";

export default function Inicio() {
  const [openBar, setOpenBar] = useState("");

  const handleGetStateBar = (openBar) => {
    setOpenBar(openBar);
  };

  return (
    <div className={styles.homeContainer}>
      <div
        className={
          !openBar
            ? styles.sideBarContainer
            : `${styles.sideBarContainer} ${styles.sideBarClose}`
        }
      >
        <SideBar handleStateBar={handleGetStateBar} />
      </div>
      <div
        className={
          !openBar
            ? styles.contentContainer
            : `${styles.contentContainer} ${styles.contentContainerClose}`
        }
      >
        <div
          className={
            !openBar
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
