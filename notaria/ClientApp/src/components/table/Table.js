import React, { useState, useEffect } from "react";
import styledComponents from "styled-components";
import DataTable, { createTheme } from "react-data-table-component";
import styles from "./Table.module.scss";
import variable from "../../scss/helpers.scss";

const Table = ({ data, columns, customStyles }) => {

    const paginacionOpciones = {
        rowsPerPageText: 'Filas por Página',
        rangeSeparatorText: 'de',
        selectAllRowsItem: true,
        selectAllRowsItemText: 'Todos'
    }

    //4 - Mostrar la data en Datatable
    return (
        <div className={styles.tableContainer}>
            <DataTable
                columns={columns}
                customStyles={customStyles}
                data={data}
                pagination
                paginationComponentOptions={paginacionOpciones}
                fixedHeader
                fixedHeaderScrollHeight="600px"
            />
        </div>
    );
};

export default Table;
