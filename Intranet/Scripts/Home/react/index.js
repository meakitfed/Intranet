import React from 'react';
import { render } from 'react-dom';
import Calendar from 'react-calendar';
import ReactTable from 'react-table'
import 'react-table/react-table.css';


class MyApp extends React.Component {
	state = {
		date: new Date(),
	}

	onChange = date => this.setState({ date })

	render() {
		return (
			<div>
				<Calendar
					onChange={this.onChange}
					value={this.state.date}
				/>
			</div>
		);
	}
}

render(<MyApp />, document.getElementById('app'));
