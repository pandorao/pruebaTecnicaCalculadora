import React, { Component } from 'react';
import { Row, Col, FormGroup, Input, Label, Button, Alert } from 'reactstrap';

export class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = { valueA: 0, valueB: 0, errors: [], message: "" };

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

    async handleSubmit(event) {
        event.preventDefault()

        fetch('Operations', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                ValueA: parseInt(this.state.valueA),
                ValueB: parseInt(this.state.valueB),
            })
        })
        .then((response) => response.json())
        .then((result) => {

            console.log(result);

            if (result.statusCode != 0) {
                this.setState({ errors: result.errors });
                return;
            }

            this.setState({ message: result.responseObject.fibonacciMessage, result: result.responseObject.resultOperation });
        })
    }

    render() {
        return (
            <div>
                <h1>Calculadora!</h1>
                <p>Prueba tecnica Juan David Lagares Arrazola. Email: juandavidlagareas@gmail.com</p>

                <div class="text-primary mt-2">
                    {this.state.message}
                </div>

                <form onSubmit={this.handleSubmit}>
                    <Row>
                        <Col xm="4">
                            <FormGroup>
                                <Label for="valueA">Valor A</Label>
                                <Input min="1" type="number" name="valueA" id="valueA" placeholder="Valor A" value={this.state.valueA} onChange={this.handleChange}/>
                            </FormGroup>
                        </Col>
                        <Col xs="4">
                            <FormGroup>
                                <Label for="valueB">Valor B</Label>
                                <Input min="1" type="number" name="valueB" id="valueB" placeholder="Valor B" value={this.state.valueB} onChange={this.handleChange} />
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