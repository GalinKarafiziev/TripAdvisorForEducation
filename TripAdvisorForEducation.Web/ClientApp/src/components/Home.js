import React, { Component } from 'react';

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            model: {
                userId: '',
                description: '',
                website: '',
                userName: '',
                categories: '',
                reviews: ''
            }
        }
    }

    getData = async () => {
        var response = await fetch('products/categories/04c57be8-485a-447d-9c71-41e24dfbba5d');
        var json = await response.json();

        console.log(JSON.parse(json))

        return JSON.parse(json)
    }

    componentWillMount() {
        this.getData().then(data => {
            this.setState({ model: data })
        })
    }

    render() {
        const { userName, description } = this.state.model;

        return (
            <div>
                <div>
                    Hello {userName}
                </div>
                <div>
                    Description {description}
                </div>
            </div>
        );
    }
}
