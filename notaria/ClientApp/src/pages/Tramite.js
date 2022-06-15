import React, { useState } from "react";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import FormSearch from "../components/formSearch/FormSearch";
import excelIcon from "../icons/excelIcon.png";
import styles from "../scss/pages/Tramite.module.scss";

export default function Tramite() {
  const [openBar, setOpenBar] = useState("");

  const handleGetStateBar = (openBar) => {
    setOpenBar(openBar);
  };
  return (
    <div className={styles.tramiteContainer}>
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
