import './plans.css';
import PropTypes from "prop-types";

function PlansSelectList({budgetPlanBases, handleChange}) {

    const handleSelectChange = (event) => {
        const selectedId = event.target.value;
        handleChange(selectedId);
    };

    return (
        <>
            <select onChange={handleSelectChange}>
                {budgetPlanBases.map(budgetPlanBase => (
                    <option key={budgetPlanBase.id} value={budgetPlanBase.id}>
                        {budgetPlanBase.dateFrom} - {budgetPlanBase.dateTo}
                    </option>
                ))}
            </select>
        </>
    );
}

PlansSelectList.propTypes = {
    budgetPlanBases: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.string.isRequired,
        dateFrom: PropTypes.string.isRequired,
        dateTo: PropTypes.string.isRequired,
    })).isRequired,
    handleChange: PropTypes.func.isRequired,
};

export default PlansSelectList;