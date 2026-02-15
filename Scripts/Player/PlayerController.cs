using Raylib_cs;
using System.Numerics;
using System.Reflection;

// Esse script é responsável por controlar o player
// Era pra ser apenas o cérebro do player
// Não deixar ficar muito grande
public class PlayerController : Entity
{
    public PlayerData _playerData = null!;
    public InputManager _inputManager = null!;
    public CollisionLogic _collisionLogic = null!;
    public GridWorldManager gridWorldManager = null!;
    public TileRegistry _tileRegistry = null!;
    public PlayerAnimator _playerAnimator = null!;
    public PlayerState _playerState;
    public PlayerMovement _playerMovement = null!;

    // Construtor com posição específica
    public PlayerController(Vector2 startPos, GridWorldManager worldManager, TileRegistry tileRegistry) : base(startPos, new Vector2(128, 128)) 
    {
        gridWorldManager = worldManager;
        _tileRegistry = tileRegistry;
        Initialize();
        Position = startPos; // Garante que a posição da Entity seja a desejada
    }

    // Construtor padrão
    public PlayerController(GridWorldManager worldManager, TileRegistry tileRegistry) : base(new Vector2(500, 500), new Vector2(128, 128))
    {
        gridWorldManager = worldManager;
        _tileRegistry = tileRegistry;
        Initialize();
    }

    private void Initialize()
    {
        _inputManager = new InputManager();
        _collisionLogic = new CollisionLogic(gridWorldManager, _tileRegistry);
        _playerData = new PlayerData();
        _playerAnimator = new PlayerAnimator();
        _playerAnimator.Init();
        _playerState = PlayerState.Idle;
        _playerMovement = new PlayerMovement(this, _inputManager, _collisionLogic, _playerData);
        ApplyData();
    }

    private void ApplyData()
    {
        this.Radius = _playerData.Radius;
        this.Size = _playerData.Size;
        this.IsActive = _playerData.IsActive;
    }

    public void PlayerChangeState(PlayerState newState)
    {
        if (CanChangeState(newState))
        {
            _playerState = newState;
        }
    }

    public bool CanChangeState(PlayerState newState)
    {
        // Regra 1: Se já for o mesmo estado, não precisa mudar
        if(_playerState == newState) return false;
        
        // Regra 2: Se estiver morto, não pode mudar para quase nada (exemplo de lógica de FSM)
        if(_playerState == PlayerState.Dead) return false;

        // Regra 3: Se estiver em diálogo, não pode sair correndo
        if(_playerState == PlayerState.InDialogue && newState == PlayerState.Walking) return false;
        
        return true;
    }
    
    public void Input(float dt)
    {
        _playerMovement.Input(dt);
    }

    public override void Update(float dt)
    {
        if(_playerState != PlayerState.Dead && _playerState != PlayerState.InDialogue)
            Input(dt);

        _playerAnimator.UpdateState(_playerState, dt);
    }

    public override void Draw()
    {
        _playerAnimator.Draw(Position, Size, Pivot, Rotation);
    }
}