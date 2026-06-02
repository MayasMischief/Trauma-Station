using Content.Shared.Throwing;
using Content.Shared.Weapons.Melee.Events;

namespace Content.Trauma.Shared.ThePharoahsCurse;

/// <summary>
/// This handles <see cref="PushedByDamageComponent"/>
/// </summary>
public sealed partial class PushedByDamageSystem : EntitySystem
{
    [Dependency] private ThrowingSystem _throwing = default!;
    [Dependency] private SharedTransformSystem _transform = default!;
    public override void Initialize()
    {
        SubscribeLocalEvent<PushedByDamageComponent, AttackedEvent>(OnMeleeHit);
        //SubscribeLocalEvent<PushedByDamageComponent, GotHitByProjectileEvent>(OnProjectileHit);
        // hitscans are slop
    }

    private void OnMeleeHit(Entity<PushedByDamageComponent> ent, ref AttackedEvent args)
    {
        var userPos = _transform.GetMapCoordinates(args.User).Position;
        var entPos = _transform.GetMapCoordinates(ent).Position;
        var throwDir = userPos - entPos;
        _throwing.TryThrow(ent, throwDir * -1);
    }

}
