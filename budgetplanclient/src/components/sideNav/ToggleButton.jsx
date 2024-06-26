function ToggleButton({ handleToggleSideNav }) {
    return (
        <button className="toggle-btn" type="button" onClick={handleToggleSideNav}>
            <i className="lni lni-grid-alt"></i>
        </button>
    );
}

export default ToggleButton;