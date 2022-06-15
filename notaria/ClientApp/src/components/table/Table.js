import React, { useState, useEffect } from "react";
import styledComponents from "styled-components";
import DataTable, { createTheme } from "react-data-table-component";
import styles from "./Table.module.scss";
import variable from "../../scss/helpers.scss";

const Table = () => {
    //1 - Configurar los hooks
    const [users, setUsers] = useState([]);

    //2 - Función para mostrar los datos con fetch
    const URL = "https://gorest.co.in/public/v2/users";
    const showData = async () => {
        const response = await fetch(URL);
        const data = await response.json();
        setUsers(data);
    };

    useEffect(() => {
        showData();
    }, []);

    //3 - Configuramos las columns para Datatable
    const columns = [
        {
            name: "ID",
            button: true,
            cell: (row) => (
                <a href="/" className={styles.noEscritura}>
                    <p>{row.id}</p>
                </a>
            ),
        },
        {
            name: "NAME",
            selector: (row) => row.name,
        },
        {
            name: "EMAIL",
            selector: (row) => row.email,
        },
        {
            name: "GENDER",
            selector: (row) => row.gender,
        },
        {
            name: "STATUS",
            cell: (row) => (
                <div
                    className={
                        row.status === "active"
                            ? styles.statusCompleted
                            : styles.statusVencido
                    }
                >
                    {row.status}
                </div>
            ),
        },
    ];

    //Personalizar temas
    const customStyles = {
        rows: {
            style: {
                background: "#DCDCDC",
                marginBottom: "8px",
                minHeight: "89px",
            },
        },
        headRow: {
            style: {
                background: "#0E1B8D",
                borderRadius: "6px 6px 6px 0px",
                marginBottom: "8px",
            },
        },
        headCells: {
            style: {
                color: "#FFF",
                fontSize: "27px",
                fontWeight: "600",
                paddingBottom: "23px",
                justifyContent: "center",
                paddingTop: "23px",
            },
        },
        cells: {
            style: {
                fontSize: "18px",
                fontWeight: "400",
                justifyContent: "center",
                lineHeight: "22px",
            },
        },
    };

    //4 - Mostrar la data en Datatable
    return (
        <div className={styles.tableContainer}>
            <DataTable
                columns={columns}
                data={users}
                pagination
                customStyles={customStyles}
            />
        </div>
    );
};

export default Table;
