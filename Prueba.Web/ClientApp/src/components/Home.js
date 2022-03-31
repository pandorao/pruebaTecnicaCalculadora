import React, { Component } from 'react';
import { Row, Col, FormGroup, Input, Label, Button } from 'reactstrap';

export class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = { valueA: 0, valueB: 0 };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    handleSubmit(event) {
        alert('ValueA: ' + this.state.valueA + 'ValueB: ' + this.state.valueB);
        this.setState({ result: parseInt(this.state.valueA) + parseInt(this.state.valueB) });
        event.preventDefault();
    }

    render() {
        return (
            <div>
                <h1>Calculadora!</h1>
                <p>Prueba tecnica Juan David Lagares Arrazola. Email: juandavidlagareas@gmail.com</p>
                <form onSubmit={this.handleSubmit}>
                    <Row>
                        <Col xm="4">
                            <FormGroup>
                                <Label for="valueA">Valor A</Label>
                                <Input type="number" name="valueA" id="valueA" placeholder="Valor A" value={this.state.valueA} onChange={this.handleChange}/>
                            </FormGroup>
                        </Col>
                        <Col xs="4">
                            <FormGroup>
                                <Label for="valueB">Valor B</Label>
                                <Input type="number" name="valueB" id="valueB" placeholder="Valor B" value={this.state.valueB} onChange={this.handleChange} />
                            </FormGroup>
                        </Col>
                        <Col xs="4">
                            <FormGroup>
                                <Label for="valueB">Resultado</Label>
                                <Input placeholder="Resultado" value={this.state.result} readOnly/>
                            </FormGroup>
                        </Col>
                    </Row>
                    <div class="mt-3">
                        <Button color="primary">Calcular</Button>
                    </div>
                </form>
            </div>
        );
    }
}