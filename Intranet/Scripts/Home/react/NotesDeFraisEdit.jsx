
class GestionNotesDeFrais extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			data: this.props.data,
			noteActive: this.props.data[0],

		};
	}

	UpdateNote(i)
	{
		this.setState(state => ({
			data: state.data,
			noteActive: this.props.data[i]
		}));
	}

	render() {
		var notes = [];
		this.state.data.slice(0).reverse().map((item, i) => {
			notes.push(<button key={i} className="btn btn-block btn-1" onClick={this.UpdateNote.bind(this, i)}>{item.Date}</button>);
		});
		return (
			<div className="GestionNotesDeFrais">
				<div className="row">
					<div className="col-lg-3 table-bordered">
						<h1 className="text-center"> Notes De Frais </h1>
						{notes}
					</div>
					<div className="col-lg-6 table-bordered">
						<NoteDeFrais initialData={this.state.noteActive} />
					</div>
				</div>
			</div>
		);
	}

}

class NoteDeFrais extends React.Component {

	/*componentDidMount()
	{
		window.setInterval(
			() => this.loadNoteDeFraisFromServer(),
			this.props.pollInterval,
		);
	}*/

	/*loadNoteDeFraisFromServer() {
		const xhr = new XMLHttpRequest();
		xhr.open('get', this.props.dataUrl, true);
		xhr.onload = () => {
			console.log("Onload : ");
			console.log(xhr.responseText);
			const data = JSON.parse(xhr.responseText);
			this.setState({ data: data});
		};
		xhr.send();
	}*/

	render()
	{
		var ligne = [];
		this.props.initialData.LignesDeFrais.map((item) => {
			ligne.push(<LigneDeFrais key={item.Id} item={item} />);
		});
		return (<table className="table table-bordered table-responsive">
			<thead>
				<tr>
					<th>Nom</th>
				</tr>
			</thead>
			<tbody>
				{ligne}
			</tbody>
		</table>);
	}
}

class LigneDeFrais extends React.Component {
	render() {
			//TODO time format
			const timestamp = Date(this.props.item.Date).toString();
			return (
				<tr>
					<td>{this.props.item.Nom}</td>
					<td>{timestamp}</td>
					<td>{this.props.item.Mission.Nom}</td>
					<td>{this.props.item.Somme}</td>
					<td>{this.props.item.Statut}</td>
				</tr>
			);
	}
}

class LigneDeFraisForm extends React.Component {
	constructor(props) {
		super(props);
		this.state = this.props.item;
		//this.state = { Nom: '', Somme: '', Mission: null, Complete: false, Date: null };
		this.handleNomChange = this.handleNomChange.bind(this);
		this.handleSommeChange = this.handleSommeChange.bind(this);
		this.handleMissionChange = this.handleMissionChange.bind(this);
		this.handleCompleteChange = this.handleCompleteChange.bind(this);
		this.handleDateChange = this.handleDateChange.bind(this);
	}
	handleNomChange(e) {
		this.setState({ Nom: e.target.value });
	}
	handleSommeChange(e) {
		this.setState({ Somme: e.target.value });
	}
	handleMissionChange(e) {
		this.setState({ Mission: e.target.value });
	}
	handleCompleteChange(e) {
		this.setState({ Complete: e.target.value });
	}
	handleDateChange(e) {
		this.setState({ Date: e.target.value });
	}
	render() {
		return (
			<form className="LigneDeFraisForm"><tr>
				<td><input
					type="text"
					placeholder="Nom"
					value={this.state.Nom}
					onChange={this.handleAuthorChange}
				/></td>
				<td><input
					type="number"
					placeholder="Somme"
					value={this.state.Somme}
					onChange={this.handleTextChange}
				/></td>
				<td><input
					type="text"
					placeholder="Mission"
					value={this.state.Mission}
					onChange={this.handleTextChange}
				/></td >
				<td><input
					type="text"
					placeholder="Etat"
					value={this.state.Complete}
					onChange={this.handleTextChange}
				/></td >
				<td><input
					type="date"
					placeholder="Date"
					value={this.state.Date}
					onChange={this.handleTextChange}
				/></td >
				<input type="submit" value="Post" />
			</tr></form>
		);
	}
}