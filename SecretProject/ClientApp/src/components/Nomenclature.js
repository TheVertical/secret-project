import React, { Component } from 'react';

export class Nomenclature extends Component {

    constructor(props) {
        super(props);
        this.state = { nomenclatures: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderNomenclatureTable(nom) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {nom.map(nomenclature =>
                        <tr key={nomenclature.id}>
                            <td>{nomenclature.id}</td>
                            <td>{nomenclature.name}</td>
                            <td>{nomenclature.description}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Nomenclature.renderNomenclatureTable(this.state.nomenclatures);
        //Блок формирования
        return (
            <div>
                <h1 id="tabelLabel">Nomeclature</h1>
                <p>My first React-based table.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('nom');
        const data = await response.json();
        this.setState({ nomenclatures: data, loading: false });
    }
}
