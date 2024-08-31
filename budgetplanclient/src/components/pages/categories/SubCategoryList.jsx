import PropTypes from 'prop-types';
import AddSubCategoryForm from './AddSubCategoryForm';

const SubCategoryList = ({subCategories, mainCategoryId, handleAction}) => {
    return (
        <ul>
            {subCategories.map(subCategory => (
                <li key={subCategory.id}>
                    <div className="d-flex align-items-center justify-content-between mb-1">
                        {subCategory.transactionCategoryName}
                        <span className="material-icons-outlined" style={{
                            'font-size': '1.5rem',
                            'color': 'red',
                            'cursor': 'pointer',
                        }}>delete_forever</span>
                    </div>
                </li>
            ))}
            <li>
                <AddSubCategoryForm mainCategoryId={mainCategoryId} handleAction={handleAction}/>
            </li>
        </ul>
    );
};

SubCategoryList.propTypes = {
    subCategories: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.string.isRequired,
        transactionCategoryName: PropTypes.string.isRequired
    })).isRequired,
    mainCategoryId: PropTypes.string.isRequired,
    handleAction: PropTypes.func.isRequired,
};

export default SubCategoryList;